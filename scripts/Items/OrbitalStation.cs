using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalStation : MonoBehaviour
{
    private FollowPlayerAsBaby followComp;
    private GameObject enemy;
    private bool isEnemyThere;
    private bool isShooting;
    [SerializeField] private GameObject shootObj;
    [SerializeField] private float speed;
    void Start()
    {
        followComp = GetComponent<FollowPlayerAsBaby>();
        StartCoroutine(Wait1());
    }

    void Update()
    {
        if (enemy != null)
        {
            isEnemyThere = true;
        }
        else
        {
            isEnemyThere = false;
        }
        if (isEnemyThere && !isShooting)
        {
            followComp.enabled = false;
            if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(enemy.transform.position.x, 0, enemy.transform.position.z)) > 0.3f)
            {
                transform.position += (new Vector3(enemy.transform.position.x, 0, enemy.transform.position.z) - new Vector3(transform.position.x, 0, transform.position.z)) * Time.deltaTime * speed;
            }
            else
            {
                StartCoroutine(Wait());
            }
        }
        else
        {
            followComp.enabled = true;
        }
    }

    private IEnumerator Wait()
    {
        if (!isShooting)
        {
            shootObj.active = true;
            isShooting = true;
            yield return new WaitForSeconds(0.3f);
            shootObj.active = false;
            yield return new WaitForSeconds(5);
            isShooting = false;
        }
    }

    private IEnumerator Wait1()
    {
        yield return new WaitForSeconds(1);
        if (enemy == null)
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy");
        }

        StartCoroutine(Wait1());
    }
}
