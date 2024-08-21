using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToFuturePosition : MonoBehaviour
{

    private Transform target;
    [SerializeField] private float GetAheadOn;
    public Vector3 finalPoint;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void LateUpdate()
    {
        transform.LookAt(finalPoint);
        //transform.LookAt(target.position);
        StartCoroutine(FollowOffset());
    }

    private IEnumerator FollowOffset()
    {
        Vector3 A = target.transform.position;
        yield return new WaitForSeconds(GetAheadOn);
        finalPoint = target.transform.position - A + target.transform.position;

    }
}
