using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfDestroyed : MonoBehaviour
{
    [SerializeField] GameObject doll;

    void Update()
    {
        if(doll == null) Destroy(gameObject);
    }
}
