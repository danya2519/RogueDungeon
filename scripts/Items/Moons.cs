using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moons : MonoBehaviour
{
    private BoxCollider boxcollider;
    void Start()
    {
        StartCoroutine(Wait());
        boxcollider = GetComponent<BoxCollider>();
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        Collider[] objectsCollisions = Physics.OverlapBox(transform.position, new Vector3(boxcollider.size.x * transform.localScale.x, boxcollider.size.y * transform.localScale.y, boxcollider.size.z * transform.localScale.z));
        foreach(Collider collider in objectsCollisions)
        {
            if(!collider.TryGetComponent<HealthComponent>(out HealthComponent healthComponent) && collider.TryGetComponent<ContactDamageComponent>(out ContactDamageComponent contactDamageComponent))
            {
                Destroy(collider.gameObject);
            }
        }
        StartCoroutine(Wait());
    }
}
