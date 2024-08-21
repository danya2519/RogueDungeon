using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCrystalBullet : MonoBehaviour
{
    [SerializeField] private float timeTillFlew;
    [SerializeField] private bool isBone;
    private GoForward goForward;
    private LookAtPlayer lookAtPlayer;
    

    void Start()
    {
        if (!isBone)
        {
            goForward = GetComponent<GoForward>();
            goForward.enabled = false;
        }
        lookAtPlayer= GetComponent<LookAtPlayer>();
        lookAtPlayer.lookNow = true;
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        lookAtPlayer.lookNow = false;
        yield return new WaitForSeconds(timeTillFlew);
        if(!isBone)
        {
            goForward.enabled = true;
        }
    }
}
