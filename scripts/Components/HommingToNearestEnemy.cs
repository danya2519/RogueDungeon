using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HommingToNearestEnemy : MonoBehaviour
{
    private GameObject nearestEnemy;
    [SerializeField] private float gravitySpeed;
    private Rigidbody rigb;

    private void Start()
    {
        rigb= GetComponent<Rigidbody>();
        StartCoroutine(Wait());
    }

    private void Update()
    {
        float dist = Vector3.Distance(nearestEnemy.transform.position, transform.position);
        Vector3 difference = new Vector3(nearestEnemy.transform.position.x, transform.position.y, nearestEnemy.transform.position.z) - transform.position;
        Vector3 moveVector = difference.normalized * gravitySpeed / dist * Time.deltaTime;
        moveVector.y = 0;
        rigb.AddForce(moveVector);
    }

    private void FindEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies != null)
        {
            GameObject tMin = null;
            float minDist = Mathf.Infinity;
            Vector3 currentPos = transform.position;
            foreach (GameObject t in enemies)
            {
                float dist = Vector3.Distance(t.transform.position, currentPos);
                if (dist < minDist)
                {
                    tMin = t;
                    minDist = dist;
                }
            }
            nearestEnemy = tMin;
        }
        else
        {
            nearestEnemy = gameObject;
        }

    }

    private IEnumerator Wait()
    {
        FindEnemy();
        yield return new WaitForSeconds(1);
        StartCoroutine(Wait());
    }
}
