using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private Animator animator;
    private MeshCollider meshCollider;

    private void Start()
    {
        animator = GetComponent<Animator>();
        meshCollider = GetComponent<MeshCollider>();

    }
}
