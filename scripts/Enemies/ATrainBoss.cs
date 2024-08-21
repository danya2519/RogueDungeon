using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATrainBoss : MonoBehaviour
{
    [SerializeField] private Transform spot;
    [SerializeField] private bool canRotate;
    private float rotationProgress;


    void Update()
    {
        if (canRotate)
        {
            rotationProgress += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, spot.rotation, rotationProgress);
        }

        transform.position = spot.position;

    }

}
