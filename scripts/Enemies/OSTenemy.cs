using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSTenemy : MonoBehaviour
{
    [SerializeField] private float blinkTime;
    [SerializeField] private float blinkReload;
    [SerializeField] private float step;
    private GameObject enemy;
    private bool isBlinking;
    [SerializeField] private GameObject image;
    void Start()
    {
        StartCoroutine(Blink());
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
        if(enemies.Count == 0)
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
                isBlinking &&
                collision.gameObject.tag != "Player" &&
                collision.gameObject.tag != "sc")
        {
            healthComponent.ChangeHealth(-1000);
        }
        else if (collision.gameObject.tag == "Player" && collision.gameObject.TryGetComponent(out HealthBar playerHealth))
        {
            playerHealth.RemoveHeart();
            playerHealth.RemoveHeart();

        }
    }

    IEnumerator Blink()
    {
        if (enemy == null)
        {
            FindEnemy();
        }
        image.active = true;
        isBlinking = true;
        transform.LookAt(new Vector3(enemy.transform.position.x, transform.position.y, enemy.transform.position.z));
        Vector3 moveVector = (enemy.transform.position - transform.position).normalized;
        moveVector.y = 0;
        transform.position += moveVector * step;
        yield return new WaitForSeconds(blinkTime);
        isBlinking = false;
        image.active = false;
        yield return new WaitForSeconds(blinkReload);
        StartCoroutine(Blink());
    }
}
