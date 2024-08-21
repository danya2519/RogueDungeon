using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    private Rigidbody rigidbody;
    private MeshRenderer meshRenderer;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * 500);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            meshRenderer.material.color = Color.red;
        }

   
    }
}
