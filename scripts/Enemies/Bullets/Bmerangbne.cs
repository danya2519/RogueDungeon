using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bmerangbne : MonoBehaviour
{
    [SerializeField] private float startSpeed;
    [SerializeField] private float speedDecrease = 0.05f;
    private Rigidbody rig;
    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rig.velocity = transform.forward * startSpeed;
        startSpeed -= speedDecrease;
    }
}
