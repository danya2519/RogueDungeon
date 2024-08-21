using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryBoss : MonoBehaviour
{
    [SerializeField] private GameObject[] bullet;
    [SerializeField] private float shootInTime;
    private void Start()
    {
        if (shootInTime != 0)
            StartCoroutine(wait());
    }
    public void Shoot(int repeat)
    {
        for (int i = 0; i < repeat; i++)
        {
            Instantiate(bullet[Random.Range(0, bullet.Length - 1)], transform.position, transform.rotation);
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        Shoot(1);
        yield return new WaitForSeconds(8.333f);
        StartCoroutine(wait());
    }
}
