using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreBoss : MonoBehaviour
{
    private ShootFallBullets shootComp;
    [SerializeField] private int loopBullets;
    void Start()
    {
        shootComp = GetComponent<ShootFallBullets>();
    }

    void Update()
    {
        if(transform.localScale.x >= 2.85f)
        {
            shootComp.Shoot(loopBullets);
        }
    }
}
