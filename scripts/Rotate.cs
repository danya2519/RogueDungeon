using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Directions rotateDirection;

    void Update()
    {
        switch (rotateDirection)
        {
            case Directions.x:
                transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
                break;
            case Directions.y:
                transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
                break;
            case Directions.z:
                transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
                break;
            default:
                break;
        }
        
    }

    public enum Directions {x, y, z}   
}
