using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderCopter : MonoBehaviour
{
    private FollowPlayerAsBaby followComp;
    private GameObject enemy;
    private bool isEnemyThere;
    [SerializeField] private float speed;
    void Start()
    {
        followComp = GetComponent<FollowPlayerAsBaby>();
        StartCoroutine(Wait());
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
        if (isEnemyThere)
        {
            followComp.enabled = false;
            transform.LookAt(new Vector3(enemy.transform.position.x, transform.position.y, enemy.transform.position.z));
            if (Vector3.Distance(transform.position, enemy.transform.position) > 3)
            {
                transform.position += (enemy.transform.position - transform.position) * Time.deltaTime * speed;
                transform.position = new Vector3(transform.position.x, enemy.transform.position.y + 1, transform.position.z);
            }
        }
        else
        {
            followComp.enabled = true;
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(Attack.shootSpeed + 0.2f);
        if(isEnemyThere) 
        { 
            Destroy(Instantiate(Attack.projectile, transform.position, transform.rotation), 5);
        }
        if(enemy == null) 
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy");
        }
        StartCoroutine(Wait());
    }
}
