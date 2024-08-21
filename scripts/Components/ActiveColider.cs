using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveColider : MonoBehaviour
{
    [SerializeField] private int time;
    [SerializeField] private Collider col;
    void Start()
    {
        col.enabled = false;
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(time);
        col.enabled = true;
    }
}
