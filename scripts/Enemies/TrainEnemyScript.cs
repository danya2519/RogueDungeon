using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainEnemyScript : MonoBehaviour
{
    private GameObject target;
    [SerializeField] private float speed;
    private Rigidbody rigidbodyComp;

    private void Start()
    {
        rigidbodyComp = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        rigidbodyComp.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out HealthBar playerHealth))
        {
            playerHealth.RemoveHeart();
        }
        if (collision.gameObject.tag == "Wall")
        {
            transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
        }
    }
}
