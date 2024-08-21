using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GoForward : MonoBehaviour
{
    [SerializeField] private bool isBulletSpeed;
    [SerializeField] private float speedmodifire;
    [SerializeField] private float speed;
    [SerializeField] private MovingType move;
    private Rigidbody rig;
    private void Start()
    {
        if (move == MovingType.Physics)
        {
            rig = GetComponent<Rigidbody>();
        }
        if (isBulletSpeed)
        {
            StartCoroutine(Wait());
        }


    }
    private void Update()
    {
        if (move == MovingType.Physics)
        {
            rig.velocity = transform.forward * speed * Time.deltaTime;
        }
        else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        speed = Attack.speed * speedmodifire;
    }

    public enum MovingType{Physics, Vector}
}
