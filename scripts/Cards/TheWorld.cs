using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorld : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        float value = Time.timeScale / 2;
        Time.timeScale -= value;
        yield return new WaitForSeconds(7.5f);
        Time.timeScale += value;
    }
}
