using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatch : MonoBehaviour
{
    private float startTime;
    [SerializeField] private float speed;
    void Start()
    {
        startTime = Time.timeScale;
        Time.timeScale = 0.1f;
    }

    void Update()
    {
        if(Time.timeScale >= startTime)
        {
            Time.timeScale = startTime;
            Destroy(gameObject);
        }
        else
        {
            Time.timeScale += (startTime - Time.timeScale) * speed;
        }
    }
}
