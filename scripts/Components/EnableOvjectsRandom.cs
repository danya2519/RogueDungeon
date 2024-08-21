using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOvjectsRandom : MonoBehaviour
{
    [SerializeField, Range(0, 60)] float maxTime;
    [SerializeField, Range(0, 60)] float minTime;
    [SerializeField] GameObject[] objectsToEnable;
    void Start()
    {
        for (int i = 0; i < objectsToEnable.Length; i++)
        {
            Wait(i);
        }
    }

    IEnumerable Wait(int number)
    {
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        objectsToEnable[number].SetActive(true);
    }
}
