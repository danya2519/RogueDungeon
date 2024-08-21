using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private GameObject enemy;
    [SerializeField] private float speed;

    void Update()
    {
        if (enemy == null)
        {
            FindEnemy();
        }
        transform.LookAt(new Vector3(enemy.transform.position.x, transform.position.y, enemy.transform.position.z));
        Vector3 moveVector = (enemy.transform.position - transform.position).normalized;
        moveVector.y = 0;
        transform.position += moveVector * speed * Time.deltaTime;
    }

    private void FindEnemy()
    {
        GameObject[] MTs = GameObject.FindGameObjectsWithTag("MT");
        GameObject[] CHAOs = GameObject.FindGameObjectsWithTag("CHAOS");
        List<GameObject> enemies = new();
        foreach (var item in MTs)
        {
            enemies.Add(item);
        }
        foreach (var item in CHAOs)
        {
            enemies.Add(item);
        }
        if (enemies.Count == 0)
        {
            enemy = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            enemy = enemies[Random.Range(0, enemies.Count)];
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
        else if (collision.gameObject.tag == "Player" && collision.gameObject.TryGetComponent(out HealthBar playerHealth))
        {
            playerHealth.RemoveHeart();

        }
    }
}
