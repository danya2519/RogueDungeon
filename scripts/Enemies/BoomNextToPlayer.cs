using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomNextToPlayer : MonoBehaviour
{
    private GameObject target;
    private bool worked = false;
    [SerializeField] private float timetillExplosion;
    [SerializeField] private float explodeDist;
    [SerializeField] private GameObject explosion;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        float dist = Vector3.Distance(target.transform.position, transform.position);
        if (!worked && dist < explodeDist)
        {
            StartCoroutine(wait());
            worked = true;
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(timetillExplosion);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
