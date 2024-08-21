using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expand : MonoBehaviour
{
    [SerializeField] private float increaseSpeed;
    void Update()
    {
        transform.localScale += new Vector3(1,1,1) * increaseSpeed * Time.deltaTime;
    }
}
