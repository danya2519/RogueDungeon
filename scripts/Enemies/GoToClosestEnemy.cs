using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToClosestEnemy : MonoBehaviour
{
    [SerializeField] private bool IsGo;
    private GameObject tMin = null;
    [SerializeField] private GameObject SFX;
    void Start()
    {
        StartCoroutine(wait());
        
    }
    private void Update()
    {
        if (IsGo)
        {
            transform.LookAt(new Vector3(tMin.transform.position.x, transform.position.y, tMin.transform.position.z));
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);
        }

    }
    private GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        tMin = enemies[Random.Range(0, enemies.Length)];
        return tMin;
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(4);
        FindClosestEnemy();
        IsGo = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            IsGo = false;
            StartCoroutine(wait());
            Instantiate(SFX, tMin.transform.position, Quaternion.identity);
            transform.Translate(Vector3.back * 4 * Time.deltaTime);
        }

    }
}
