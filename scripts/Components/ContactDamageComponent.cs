using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamageComponent : MonoBehaviour
{
    [SerializeField] private bool isTrigger;
    [SerializeField] private bool isCollider;

    [Header("Raycast")]
    [SerializeField] private bool isRaycast;
    [SerializeField] private float range;

    private void OnCollisionEnter(Collision collision)
    {
        if(isCollider && collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.TryGetComponent(out HealthBar playerHealth))
            {
                playerHealth.RemoveHeart();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isTrigger && other.gameObject.tag == "Player")
        {
            if (other.gameObject.TryGetComponent(out HealthBar playerHealth))
            {
                playerHealth.RemoveHeart();
            }
        }
    }

    private void Update()
    {
        if (isRaycast)
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, range))
            {
                if (hit.collider.TryGetComponent(out HealthBar playerHealth))
                {
                    playerHealth.RemoveHeart();
                }
            }
        }
    }
}
