using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;


public class MTOrChaos : MonoBehaviour
{
    [SerializeField] private int medCids;
    private Vector3 moveVector;
    private HealthComponent HC;
    private LookAtPlayer lookAtComp;
    private GameObject enemy;
    [SerializeField] private Transform shootFrom;
    [SerializeField] private float speed;
    [SerializeField] private float shootSpeed;
    [SerializeField] private float reloadTime;
    [SerializeField] private int bulletsInMagazine;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject HealFX;
    [SerializeField] private bool isMT;


    private void Start()
    {
        medCids = Random.Range(1, 3);
        HC = GetComponent<HealthComponent>();
        lookAtComp = GetComponent<LookAtPlayer>();
        StartCoroutine(Shoot(bulletsInMagazine));
        FindEnemy();
    }

    private void Update()
    {
        transform.Translate(moveVector * Time.deltaTime * speed);
        if(lookAtComp.target == null)
        {
            FindEnemy();
        }
    }

    IEnumerator Shoot(int loops)
    {
        if(Random.Range(0,2) == 1)
        {
            moveVector = transform.right;
        }
        else
        {
            moveVector = transform.right * -1;
        }
        for (int i = 0; i < loops; i++)
        {
            Instantiate(bullet, shootFrom.position, shootFrom.rotation);
            yield return new WaitForSeconds(shootSpeed);
        }
        if(HC.GetHealth() < 250 && medCids > 0) 
        {
            StartCoroutine(Heal());
        }
        else
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Heal()
    {
        moveVector = transform.forward;
        yield return new WaitForSeconds(3f);
        moveVector = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(2f);
        HC.ChangeHealth(210);
        medCids--;
        Instantiate(HealFX, transform.position, Quaternion.identity);
        StartCoroutine(Reload());
    }

    private void FindEnemy()
    {
        List<GameObject> enemies = new();
        if (!isMT)
        {
            GameObject[] MTs = GameObject.FindGameObjectsWithTag("MT");
            foreach (var item in MTs)
            {
                enemies.Add(item);
            }
        }
        else
        {
            GameObject[] CHAOs = GameObject.FindGameObjectsWithTag("CHAOS");
            foreach (var item in CHAOs)
            {
                enemies.Add(item);
            }
        }
        GameObject[] sCes = GameObject.FindGameObjectsWithTag("sc");
        foreach (var item in sCes)
        {
            enemies.Add(item);
        }
        enemies.Add(GameObject.FindGameObjectWithTag("Player"));
        enemy = enemies[Random.Range(0, enemies.Count)];
        lookAtComp.target = enemy;
    }

    IEnumerator Reload()
    {
        moveVector = transform.forward * -1;
        yield return new WaitForSeconds(reloadTime);
        StartCoroutine(Shoot(bulletsInMagazine));
    }
}
