using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRot : MonoBehaviour
{
    void Start()
    {
        transform.localRotation = transform.localRotation * Quaternion.Euler(0,1,1);
    }
}
