using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PpooEnemy : MonoBehaviour
{
    [SerializeField] private float pauseOn;
    [SerializeField] private float speed;
    private LookAtPlayer LookComp;
    private Rigidbody rig;
    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        LookComp = GetComponent<LookAtPlayer>();
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(pauseOn);
        LookComp.LookAtP();
        rig.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
        StartCoroutine(wait());
    }
}
