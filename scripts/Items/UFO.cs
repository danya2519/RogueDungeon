using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    private FollowPlayerAsBaby followComp;
    private GameObject enemy;
    private GameObject player;
    private bool isShooting;
    private bool isEnemyThere;
    [SerializeField] private GameObject particles;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float speedModifier = 1;
    void Start()
    {
        followComp = GetComponent<FollowPlayerAsBaby>();
        player = GameObject.FindWithTag("Player");
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
        if (isEnemyThere)
        {
            followComp.enabled = false;
            if (!isShooting)
            {
                StartCoroutine(Wait());
            }

        }
        else
        {
            if(!followComp.enabled)
            {
                Instantiate(particles, transform.position, Quaternion.identity);
                Vector3 teleportTo = player.transform.position + new Vector3(Random.Range(-2, 2), Random.Range(0, 2), Random.Range(-2, 2));
                Instantiate(particles, teleportTo, Quaternion.identity);
            }

            followComp.enabled = true;
        }
    }

    private IEnumerator Wait()
    {
        isShooting = true;
        Instantiate(particles, transform.position, Quaternion.identity);
        transform.position = new Vector3(0, 50, 0);
        yield return new WaitForSeconds(0.5f * speedModifier);
        if (enemy! != null)
        {
            Vector3 teleportTo = enemy.transform.position + new Vector3(Random.Range(-2, 2), Random.Range(0, 2), Random.Range(-2, 2));
            Instantiate(particles, teleportTo, Quaternion.identity);
            yield return new WaitForSeconds(0.2f * speedModifier);
            transform.position = teleportTo;
        }
        if(enemy !!= null)
        {
            transform.LookAt(new Vector3(enemy.transform.position.x, transform.position.y, enemy.transform.position.z));
        }
        Instantiate(bullet, transform.position, transform.rotation);
        transform.rotation = Quaternion.identity;
        if (speedModifier < 0.5f)
        {
            //enemy = GameObject.FindGameObjectWithTag("Enemy");
        }
        yield return new WaitForSeconds(1f * speedModifier);
        isShooting = false;
    }

    private IEnumerator Wait1()
    {
        yield return new WaitForSeconds(speedModifier * 2 * 1);
        if (enemy == null)
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy");
        }
        StartCoroutine(Wait1());
    }
}
