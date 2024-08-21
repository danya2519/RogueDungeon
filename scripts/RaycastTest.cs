using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    private void Update()
    {
        


        Ray myRay = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 100, Color.red);
        

        if (Physics.Raycast(myRay, out RaycastHit hit))
        {
            hit.rigidbody.AddForce(Vector3.up * 50);
        }
    }
}
