using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowElectricity : MonoBehaviour
{
    private GameObject target;
    private bool isFollowNow = true;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(wait());
    }
    void Update()
    {
        if(isFollowNow)
        {
            transform.position = target.transform.position;
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        isFollowNow = false;
    }
}
