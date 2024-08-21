using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SedelScript : MonoBehaviour
{
    private Expand sizeComp;
    private ContactDamageComponent contactComp;
    private Rigidbody rig;
    private GameObject player;
    void Start()
    {
        sizeComp= GetComponent<Expand>();
        contactComp= GetComponent<ContactDamageComponent>();
        rig = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Wait1());
    }

    private IEnumerator Wait1()
    {
        rig.useGravity = false;
        transform.position = player.transform.position + new Vector3(0,3,0);
        yield return new WaitForSeconds(1);
        rig.useGravity = true;
        sizeComp.enabled = false;
        yield return new WaitForSeconds(0.3f);
        contactComp.enabled = false;

    }
}
