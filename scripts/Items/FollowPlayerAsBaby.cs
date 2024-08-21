using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerAsBaby : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float dist;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) > dist)
        {
            transform.position += (player.transform.position - transform.position) * Time.deltaTime * speed;
            transform.position = new Vector3(transform.position.x, player.transform.position.y + 1, transform.position.z);
        }
    }
}
