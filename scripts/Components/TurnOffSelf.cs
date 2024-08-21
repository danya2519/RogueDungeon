using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffSelf : MonoBehaviour
{
    [SerializeField] private float time;
    void OnEnable()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
