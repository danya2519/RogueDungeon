using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fn : MonoBehaviour
{
    private GameObject enemy;
    [SerializeField] private Animator animator;
    [SerializeField] private bool isNotCreatingZombie;
    [SerializeField] private float speed;
    [SerializeField] private GameObject zombie;
    


    void Update()
    {
        if(enemy == null)
        {
            FindEnemy();
        }
        transform.LookAt(new Vector3(enemy.transform.position.x, transform.position.y, enemy.transform.position.z));
        Vector3 moveVector = (enemy.transform.position - transform.position).normalized;
        moveVector.y = 0;
        transform.position += moveVector * speed * Time.deltaTime;
        if(Vector3.Distance(transform.position, enemy.transform.position) < 1 && enemy.gameObject.tag == "corpse" && isNotCreatingZombie)
        {
            StartCoroutine(CreateZombie());
        }
    }

    private void FindEnemy()
    {
        GameObject[] mTs = GameObject.FindGameObjectsWithTag("MT");
        GameObject[] cHAOs = GameObject.FindGameObjectsWithTag("CHAOS");
        GameObject corpse = GameObject.FindGameObjectWithTag("corpse");
        if(corpse == null) 
        { 
        List<GameObject> enemies = new();
        foreach (var item in mTs)
        {
            enemies.Add(item);
        }
        foreach (var item in cHAOs)
        {
            enemies.Add(item);
        }
        if (enemies.Count == 0)
        {
            enemy = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            enemy = enemies[UnityEngine.Random.Range(0, enemies.Count)];
        }
        }
        else
        {
            enemy = corpse;
        }

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<HealthComponent>(out HealthComponent healthComponent) &&
                collision.gameObject.tag != "Player" &&
                collision.gameObject.tag != "sc")
        {
            healthComponent.ChangeHealth(-300);
        }
        else if(collision.gameObject.tag == "Player" && collision.gameObject.TryGetComponent(out HealthBar playerHealth))
        {
            playerHealth.RemoveHeart();
            playerHealth.RemoveHeart();
        }
    }

    IEnumerator CreateZombie()
    {
        animator.SetTrigger("Revive");
        isNotCreatingZombie = false;
        float savedspeed = speed;
        speed = 0;
        yield return new WaitForSeconds(5f);
        Destroy(enemy);
        Instantiate(zombie, transform.position, Quaternion.identity);
        FindEnemy();
        speed = savedspeed;
        isNotCreatingZombie = true;
    }


}
