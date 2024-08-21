using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baloon : MonoBehaviour
{
    private Rigidbody rigidbody;
    public float jumpHeight;
    public float forwardForce;
    [SerializeField] private int loopBullets;
    [SerializeField] private GameObject bullet;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(jump());
    }

    IEnumerator jump()
    {
        rigidbody.AddForce(transform.forward * forwardForce + transform.up * jumpHeight, ForceMode.Impulse);
        yield return new WaitForSeconds(1);
        for (int i = 0; i < loopBullets; i++)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(3);
        StartCoroutine(jump());
    }
}
