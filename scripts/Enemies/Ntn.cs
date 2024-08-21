using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ntn : MonoBehaviour
{
    private GameObject enemy;
    private Transform spot;
    [SerializeField] private float speed;
    void Update()
    {
        if (enemy == null)
        {
            FindEnemy();
        }
        Vector3 moveVector = new Vector3();
        if (enemy.gameObject.tag == "Player")
        {
            if (Input.anyKey)
            {
                spot.position = enemy.transform.position;
                moveVector = (spot.position - transform.position).normalized;
                transform.LookAt(new Vector3(spot.position.x, transform.position.y, spot.position.z));
            }
        }
        else
        {
            moveVector = (enemy.transform.position - transform.position).normalized;
            transform.LookAt(new Vector3(enemy.transform.position.x, transform.position.y, enemy.transform.position.z));
        }
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
}
