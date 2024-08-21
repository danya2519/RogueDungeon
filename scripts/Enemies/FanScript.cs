using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanScript : MonoBehaviour
{
    private GameObject target;
    [SerializeField] private float speed;
    [SerializeField] private float range;

    private float distanceToPlayer;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {

        distanceToPlayer= Vector3.Distance(target.transform.position, transform.position); 

        if (distanceToPlayer < range)
        {
            Vector3 moveVector = (transform.position - target.transform.position).normalized;
            target.GetComponent<CharacterController>().Move(moveVector * speed);
        }
    }

  
 
}
