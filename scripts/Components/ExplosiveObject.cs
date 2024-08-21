using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveObject : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private Vector3 radius;
    [SerializeField] private Vector3 fixedSpawn;
    [SerializeField] private GameObject explosionParticles;
    [SerializeField] private int loopParticles;

    public void Explode()
    {
        if(health <= 0)
        {
            for (int i = 0; i < loopParticles; i++)
            {
                Instantiate(explosionParticles, fixedSpawn + transform.position + new Vector3(Random.Range(-radius.x, radius.x), Random.Range(-radius.y, radius.y), Random.Range(-radius.z, radius.z)), transform.rotation);
            }
            Destroy(gameObject);
        }
        else
        {
            health--;
        }
    }
}
