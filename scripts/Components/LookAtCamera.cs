using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public bool lookNow = true;
    private GameObject mainCamera;

    private void Start()
    {
        mainCamera = GameObject.Find("MainCamera");
    }
    private void Update()
    {
        if (lookNow)
        {
            transform.LookAt(mainCamera.transform.position);
        }
    }
}
