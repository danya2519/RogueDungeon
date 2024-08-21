using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bssr : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject trapdoor;
    private GameObject livingBoss;
    private BoxCollider boxCollider;
    private bool canCheck;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            boxCollider.enabled = false;
            livingBoss = Instantiate(boss, transform.position, transform.rotation);
            canCheck = true;
        }
    }

    private void Update()
    {
        if(canCheck && livingBoss == null) 
        {
            Instantiate(trapdoor, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
