using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageToEnemys : MonoBehaviour
{
    [SerializeField] private float damageD;
    [SerializeField] private bool deleteOnTouch;
    [SerializeField] private bool playerDamage = false;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (playerDamage)
        {
            damageD *= Attack.damage;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<HealthComponent>(out HealthComponent healthComponent) &&
                collision.gameObject.tag != "Player")
        {
            healthComponent.ChangeHealth(-Mathf.RoundToInt(damageD));
            if(deleteOnTouch)
            {
                Destroy(gameObject, 0.05f);
            }
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<HealthComponent>(out HealthComponent healthComponent) &&
                collision.gameObject.tag != "Player")
        {
            healthComponent.ChangeHealth(-Mathf.RoundToInt(damageD));
            if (deleteOnTouch)
            {
                Destroy(gameObject, 0.05f);
            }
        }
    }
}
