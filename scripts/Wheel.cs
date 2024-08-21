using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    private Rigidbody carRigidbody;

    private void Start()
    {
        carRigidbody = GetComponentInParent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            carRigidbody.AddForce(Vector3.forward * 50);
        }
    }
}
