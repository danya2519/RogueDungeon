using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Rotate;

public class LookRandomRot : MonoBehaviour
{
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, Random.Range(0,359), 0);
    }
}
