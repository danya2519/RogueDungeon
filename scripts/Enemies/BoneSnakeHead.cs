using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneSnakeHead : MonoBehaviour
{

    private Transform target;
    [SerializeField]private GameObject rotBulletSpawner;
    [SerializeField]private GameObject Brim;
    [SerializeField]private GameObject fallBulletShooter;
    [SerializeField]private GameObject BoneBulletShooter;
    [SerializeField]private GameObject head;
    [SerializeField]private GameObject randomElectricShooter;
    [Range(1,5)] private int nextAttack;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rotBulletSpawner.SetActive(false);
        Brim.SetActive(false);
        BoneBulletShooter.SetActive(false);
        randomElectricShooter.SetActive(false);
        StartCoroutine(SelektAttack());
    }
    
    private IEnumerator SelektAttack()
    {
        yield return new WaitForSeconds(0.1f);
        nextAttack = Random.Range(1, 5);
        if(nextAttack == 1)
        {
            StartCoroutine(Attack1());
        }
        else if(nextAttack == 2) 
        {
            StartCoroutine(Attack2());
        }
        else if (nextAttack == 3)
        {
            StartCoroutine(Attack3());
        }
        else if (nextAttack == 4)
        {
            StartCoroutine(Attack4());
        }
        else
        {
            StartCoroutine(Attack5());
        }
    }


    private IEnumerator Attack35()
    {
        transform.LookAt(target.position);
        yield return new WaitForSeconds(1);
        Brim.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Brim.SetActive(false);
    }


    private IEnumerator Attack1()
    {
        fallBulletShooter.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        fallBulletShooter.SetActive(false);
        yield return new WaitForSeconds(6);
        StartCoroutine(SelektAttack());
    }


    private IEnumerator Attack2()
    {
        rotBulletSpawner.SetActive(true);
        yield return new WaitForSeconds(2);
        rotBulletSpawner.SetActive(false);
        yield return new WaitForSeconds(4);
        StartCoroutine(SelektAttack());
    }


    private IEnumerator Attack3()
    {
        for (int i = 0; i < 4; i++)
        {
            StartCoroutine(Attack35());
            yield return new WaitForSeconds(2);
        }
        StartCoroutine(SelektAttack());
    }
    private IEnumerator Attack4()
    {
        BoneBulletShooter.SetActive(true);
        yield return new WaitForSeconds(3);
        BoneBulletShooter.SetActive(false);
        yield return new WaitForSeconds(1);
        StartCoroutine(SelektAttack());
    }
    private IEnumerator Attack5()
    {
        randomElectricShooter.SetActive(true);
        yield return new WaitForSeconds(6);
        randomElectricShooter.SetActive(false);
        yield return new WaitForSeconds(2);
        StartCoroutine(SelektAttack());
    }
}
