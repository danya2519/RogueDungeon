using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyScript : MonoBehaviour
{
    private GameObject target;
    [SerializeField] private float speed;
    private Rigidbody rigidbodyComp;
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        rigidbodyComp = GetComponent<Rigidbody>();
    }
    void Update()
    {
        transform.LookAt(new Vector3(target.transform.position.x, target.transform.position.y + 1, target.transform.position.z));
        rigidbodyComp.velocity = transform.forward * speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.TryGetComponent(out HealthBar playerHealth))
            {
                playerHealth.RemoveHeart();
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
    rigidbodyComp.velocity = transform.up * speed;
    }
}
