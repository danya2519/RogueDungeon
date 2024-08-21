using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneEnemyScrit : MonoBehaviour
{
    private Rigidbody rig;
    private GameObject target;
    private bool ready;
    [SerializeField] private GameObject Explode;
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        rig.useGravity = false;
        rig.AddForce(new Vector3(0, 6, 0), ForceMode.Impulse);
        target = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        rig.velocity = Vector3.zero;
        transform.LookAt(target.transform.position);
        yield return new WaitForSeconds(0.5f);
        rig.velocity = transform.forward * 10;
        ready = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (ready)
        {
            Instantiate(Explode, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
