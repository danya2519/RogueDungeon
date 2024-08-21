using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HummerExplode : MonoBehaviour
{
    private ShootFallBullets shootComp;
    private void Start()
    {
        shootComp = GetComponent<ShootFallBullets>();
    }
    void Update()
    {
        if(transform.localScale.y > 1)
        {
            shootComp.Shoot(3);
        }
    }
}
