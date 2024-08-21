using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFallBullets : MonoBehaviour
{
    [SerializeField] private GameObject[] bullet;
    [SerializeField] protected Vector3 offset;
    [SerializeField] protected float shootInTime;
    void OnEnable()
    {
        if (shootInTime != 0)
            StartCoroutine(wait());
    }
    public void Shoot(int repeat)
    {
        for (int i = 0; i < repeat; i++)
        {
            if (bullet.Length == 1)
            {
                Instantiate(bullet[0], transform.position + offset, transform.rotation);
            }
            else
            {
                Instantiate(bullet[Random.Range(0,bullet.Length - 1)], transform.position + offset, transform.rotation);
            }
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(shootInTime);
        Shoot(1);
        StartCoroutine(wait());
    }
}
