using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] float explosionTime;
    [SerializeField] float explosionRadius;
    [SerializeField] float explosionForce;

    private float timer;
    private bool explode;

    [SerializeField] GameObject destroyFx;

    private void Start()
    {
        explode = false;
        timer = explosionTime;
    }
    private void Update()
    {
        timer-= Time.deltaTime;
            
        if(timer <= 0 && !explode)
        {
            Explode();
        }

    }
    private void Explode()
    {
        explode = true;
        Collider[] colidersToDamage = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider colider in colidersToDamage) 
        {
            if (colider.TryGetComponent(out HealthBar playerHealth))
            {
                playerHealth.RemoveHeart();
            }
            else if (colider.TryGetComponent(out HealthComponent health))
            {
                health.ChangeHealth(-100);
            }
            else if (colider.TryGetComponent(out ExplosiveObject ExplodeComp))
            {
                ExplodeComp.Explode();
            }
        }
        Collider[] colidersToMove = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider colider in colidersToMove)
        {
            if (colider.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
        Instantiate(destroyFx, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
