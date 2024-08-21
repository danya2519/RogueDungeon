using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotoBoss : MonoBehaviour
{
    [SerializeField] private GameObject sedel;
    [SerializeField] private GameObject sedelBullet;
    [SerializeField] private bool sedelBool;
    [SerializeField] private GameObject FuelTank;
    [SerializeField] private GameObject FuelTankBullet;
    [SerializeField] private bool FuelTankBool;
    [SerializeField] private GameObject FirstRocket;
    [SerializeField] private GameObject FirstRocketBullet;
    [SerializeField] private bool FirstRocketBool;
    [SerializeField] private GameObject Part;
    [SerializeField] private GameObject PartBullet;
    [SerializeField] private bool PartBool;
    [SerializeField] private GameObject wheel;
    [SerializeField] private GameObject wheelBullet;
    [SerializeField] private bool wheelBool;
    private HealthComponent healthComp;
    void Start()
    {
        healthComp = GetComponent<HealthComponent>();
        StartCoroutine(Wait1());
    }

    private IEnumerator Wait1()
    {
        yield return new WaitForSeconds(4);
        if(healthComp.GetHealth() < 700 && !PartBool)
        {
            PartBool = true;
            Destroy(Part);
            Instantiate(PartBullet, transform.position, transform.rotation);
        }
        if (healthComp.GetHealth() < 550 && !sedelBool)
        {
            sedelBool = true;
            Destroy(sedel);
            Instantiate(sedelBullet, transform.position, transform.rotation);
        }
        if (healthComp.GetHealth() < 450 && !FirstRocketBool)
        {
            FirstRocketBool = true;
            Destroy(FirstRocket);
            Instantiate(FirstRocketBullet, transform.position, transform.rotation);
        }
        if (healthComp.GetHealth() < 250 && !FuelTankBool)
        {
            FuelTankBool = true;
            Destroy(FuelTank);
            Instantiate(FuelTankBullet, transform.position, transform.rotation);
        }
        if (healthComp.GetHealth() < 240 && !wheelBool)
        {
            wheelBool = true;
            Destroy(wheel);
            Instantiate(wheelBullet, transform.position, transform.rotation);
            transform.rotation = Quaternion.Euler(transform.rotation.x - 15, transform.rotation.y, transform.rotation.z);
        }
        StartCoroutine(Wait1());
    }
}

