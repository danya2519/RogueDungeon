using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSecond : MonoBehaviour
{
    [SerializeField] private int enableIn;
    [SerializeField] private GameObject objectToEnable;
    void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(enableIn);
        objectToEnable.active = true;
    }
}
