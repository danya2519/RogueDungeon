using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIreBossStand : MonoBehaviour
{
    [SerializeField] private bool isOnFire;
    [SerializeField] private GameObject eye;
    [SerializeField] private GameObject smoke;
    [SerializeField] private GameObject eyeBullet;
    [SerializeField] private GameObject bossHealth;
    [SerializeField] private GameObject[] fireStands;

    private void Start()
    {
        StartCoroutine(Wait());
    }

    void Update()
    {
        if(isOnFire)
        {
            eye.SetActive(true);
            smoke.SetActive(false);
            bossHealth.transform.position = transform.position;
        }
        else
        {
            eye.SetActive(false);
            smoke.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FireEye")
        {
            Destroy(collision.gameObject);
            isOnFire = true;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        if (isOnFire && Random.Range(1,5) <= 1)
        {
            GameObject ChoosedfireStand = fireStands[Random.Range(0, 2)];
            GameObject bullet = Instantiate(eyeBullet, transform.position + (ChoosedfireStand.transform.position - transform.position) / 5, Quaternion.identity);
            bullet.transform.LookAt(new Vector3(ChoosedfireStand.transform.position.x, transform.position.y, ChoosedfireStand.transform.position.z));
            isOnFire = false;
        }
        StartCoroutine(Wait());
    }
}
