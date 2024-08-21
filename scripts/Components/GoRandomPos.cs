using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoRandomPos : MonoBehaviour
{
    [SerializeField] private Vector3 radius;
    void Start()
    {
        transform.position += new Vector3(Random.Range(-radius.x, radius.x), 0, Random.Range(-radius.z, radius.z));
    }
}
