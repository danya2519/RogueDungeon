using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joinobjects : MonoBehaviour
{
    [SerializeField] private GameObject rootTo;
    void Update()
    {
        transform.position = rootTo.transform.position;
    }
}
