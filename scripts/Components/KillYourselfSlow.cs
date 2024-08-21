using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillYourselfSlow : MonoBehaviour
{
    [SerializeField] private int decreaseHealthPerSecond;
    private HealthComponent HC;
    void Start()
    {
        StartCoroutine(Wait());
        HC = GetComponent<HealthComponent>();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        HC.ChangeHealth(-decreaseHealthPerSecond);
        StartCoroutine(Wait());
    }
}
