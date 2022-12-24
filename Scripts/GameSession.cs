using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameSession : MonoBehaviour {

    [SerializeField] int playerLives = 5;
    [SerializeField] int score = 0;

    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;
    [SerializeField] AudioClip DeathSoundSFX;


    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
	}

    public void AddToScore (int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    public void ProcessPlayerDeath()
    {

        if (playerLives > 1)
        {
                    AudioSource.PlayClipAtPoint(DeathSoundSFX, Camera.main.transform.position);
            TakeLife();

        }
        else
        {
            ResetGameSession();
        }
    }

    private void TakeLife()
    {

        playerLives--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString();

    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(2);
        Destroy(gameObject);
    }
}
