using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBullet : MonoBehaviour
{
    private ParticleSystem ParticleSystem_particleSystem;
    private BoxCollider Box_Collider;
    private GameObject target;
    private Vector3 GoTo;
    void Start()
    {
        transform.position = new Vector3(999, 0, 0);
        transform.rotation = Quaternion.identity;
        ParticleSystem_particleSystem = GetComponent<ParticleSystem>();
        Box_Collider = GetComponent<BoxCollider>();
        target = GameObject.FindGameObjectWithTag("Player");
        Box_Collider.enabled = false;
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        GoTo = target.transform.position;
        yield return new WaitForSeconds(1);
        transform.position = GoTo;
        Box_Collider.enabled = true;
        ParticleSystem_particleSystem.Play();
        Destroy(gameObject, 0.5f);
    }
}
