using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonBoss : MonoBehaviour
{
    private HealthComponent Hc;
    private Baloon baloonComp;
    void Start()
    {
        Hc = GetComponent<HealthComponent>();
        baloonComp = GetComponent<Baloon>();
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        baloonComp.forwardForce = 10 - Hc.GetHealth() / 75;
        StartCoroutine(Wait());
    }
}
