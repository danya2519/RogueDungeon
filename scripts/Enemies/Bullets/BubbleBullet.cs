using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBullet : MonoBehaviour
{
    private float startSpeed;
    [SerializeField] private float speedDecrease = 0.05f;
    [SerializeField] private GameObject popSFX;
    private Rigidbody rig;
    private GameObject player;
    private Attack attackComp;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        startSpeed = Attack.speed;
    }
    private void Update()
    {
        if(startSpeed > 0)
        {
            rig.velocity = transform.forward * startSpeed;
            startSpeed -= speedDecrease;
        }
        else
        {
            rig.velocity = new Vector3(0, 0, 0);
        }
    }

    private void OnDestroy()
    {
        Instantiate(popSFX, transform.position, Quaternion.identity);
    }
}
