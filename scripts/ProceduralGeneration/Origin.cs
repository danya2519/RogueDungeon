using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Origin : MonoBehaviour
{
    [SerializeField] private float checkRadius = 3f;
    [SerializeField] private LayerMask layerForOriginDestroing;

    private void Start()
    {
        if (Physics.OverlapSphere(transform.position, checkRadius, layerForOriginDestroing).Length >= 2)
        {
            ProceduralGeneration.Instance.RemoveOriginFromList(this);
            Destroy(gameObject);
        }
    }
}
