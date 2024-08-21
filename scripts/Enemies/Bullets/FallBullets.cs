using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBullets : MonoBehaviour
{
    private Rigidbody rig;
    [SerializeField] private float speed;
    [SerializeField, Range(0,500)] private float minForwardspeed;
    [SerializeField, Range(0, 500)] private float maxForwardspeed;
    [SerializeField] private float XSpeed;
    [SerializeField] private float ZSpeed;
    [SerializeField] private float modifire = 1;
    [SerializeField] private bool CanGoForward = false;
    private void Start()
    {
        Destroy(gameObject, 10);
        rig = GetComponent<Rigidbody>();
        if (CanGoForward)
        {
            rig.AddForce(transform.forward * Random.Range(minForwardspeed, maxForwardspeed));
            XSpeed = Random.Range(-100f * modifire, 100f * modifire);
            rig.AddForce(transform.right * XSpeed / 50);
        }
        else
        {
            XSpeed = Random.Range(-100f * modifire, 100f * modifire);
            ZSpeed = Random.Range(-100f * modifire, 100f * modifire);
        }
        rig.AddForce(new Vector3(XSpeed / 50, speed, ZSpeed / 50), ForceMode.Impulse);
    }
}
