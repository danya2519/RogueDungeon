using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtNearestEnemyOrPlayer : MonoBehaviour
{
    private bool isEnemiesThere;
    private GameObject nearestEnemy;
    private GameObject player;
    [SerializeField] private bool AxisYOnly;
    [SerializeField] private GameObject shootObj;
    void Start()
    {
        StartCoroutine(Wait1());
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {

        if (isEnemiesThere && AxisYOnly)
        {
            transform.LookAt(new Vector3(nearestEnemy.transform.position.x, transform.position.y, nearestEnemy.transform.position.z));
        }
        else if (isEnemiesThere)
        {
            transform.LookAt(nearestEnemy.transform.position);
        }
        else if (!isEnemiesThere && AxisYOnly)
        {
            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        }
        else
        {
            transform.LookAt(player.transform.position);
        }

    }


    private IEnumerator Wait1()
    {

        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            isEnemiesThere = true;
            FindNearestEnemy();
        }
        else
        {
            isEnemiesThere = false;
        }
        print(isEnemiesThere);
        shootObj.SetActive(isEnemiesThere);
        yield return new WaitForSeconds(3);
        StartCoroutine(Wait1());
    }

    private void FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
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
}
