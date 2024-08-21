using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntenaScript : MonoBehaviour
{
    [SerializeField] private Transform point;
    private LineRenderer LineRendererComp;
    private LookToFuturePosition LKTFPComp;
    void Start()
    {
        LineRendererComp = GetComponent<LineRenderer>();
        if(TryGetComponent(out LookToFuturePosition Health)) ;
        {
            LKTFPComp = Health;
        }

    }
    void Update()
    {
        LineRendererComp.SetPosition(0, transform.position);
        if(LKTFPComp != null )
        {
            LineRendererComp.SetPosition(1, LKTFPComp.finalPoint);
        }
        else
        {
            LineRendererComp.SetPosition(1, point.position);
        }
    }
}
