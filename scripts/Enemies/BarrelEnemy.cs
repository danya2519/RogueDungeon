using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelEnemy : MonoBehaviour
{
    [SerializeField] private bool isIn;
    [SerializeField] private GameObject barrelHealth;
    [SerializeField] private GameObject barrelPrefab;
    [SerializeField] private GameObject monkeyPrefab;
    void Start()
    {
        barrelHealth = GameObject.FindGameObjectWithTag("Barrelhealth");
        if(isIn)
        {
            StartCoroutine(Wait());
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "monkey")
        {
            Destroy(collision.gameObject);
            isIn = true;
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        if(isIn)
        {
            GameObject newBarrel = Instantiate(barrelPrefab, transform.parent);
            newBarrel.transform.position = newBarrel.transform.position + new Vector3(Random.Range(-4,4), 0, Random.Range(-4, 4));
            while(Vector3.Distance(newBarrel.transform.position, transform.position) < 2)
            {
                newBarrel.transform.position = newBarrel.transform.position + new Vector3(Random.Range(-4, 4), 0, Random.Range(-4, 4));
            }
            newBarrel.transform.LookAt(transform.position);
            transform.LookAt(newBarrel.transform.position);
            yield return new WaitForSeconds((float)barrelHealth.GetComponent<HealthComponent>().GetHealth() / 100f * 2);
            GameObject bullet = Instantiate(monkeyPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(newBarrel.transform.position);
            isIn = false;
            Destroy(gameObject, 0.1f);
        }
    }
}
