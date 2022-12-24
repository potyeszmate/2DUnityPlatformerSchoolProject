using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public float timeLimit = 6.0f;
    public float timeEllapsed = 0.0f;

    void OnEnable() {
        this.timeEllapsed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        this.timeEllapsed += Time.deltaTime;

        if(timeEllapsed > timeLimit) {
            this.gameObject.SetActive(false);
        }
    }
}
