using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBullet : MonoBehaviour
{
    private Rigidbody rigb;
    private GameObject target;
    [SerializeField] private float speed;
    [SerializeField] private float gravitySpeed;
    void Start()
    {
        rigb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        float dist = Vector3.Distance(target.transform.position, transform.position);
        Vector3 difference = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z) - transform.position;
        Vector3 moveVector = difference.normalized * gravitySpeed / dist * Time.deltaTime ;
        moveVector.y = 0;
        rigb.AddForce(moveVector);
    }
}
