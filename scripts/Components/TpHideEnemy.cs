using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpHideEnemy : MonoBehaviour
{
    [SerializeField] private float hideFor;
    [SerializeField] private float shootFor;
    [SerializeField] private float beforeShoot;
    [SerializeField] private float waitTillatack;
    [SerializeField] private int shootCicles;
    private GameObject target;
    private ShootFallBullets SFBComp;
    private BoxCollider colliderComp;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        SFBComp = GetComponent<ShootFallBullets>();
        colliderComp = GetComponent<BoxCollider>();
        colliderComp.enabled = false;
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        transform.position = target.transform.position + new Vector3(0,-5,0);
        transform.rotation = Quaternion.Euler(0, Random.Range(0, 359), 0);
        yield return new WaitForSeconds(waitTillatack);

        transform.position = target.transform.position;

        transform.Translate(Vector3.forward * Random.Range(3, 5));

        colliderComp.enabled= true;

        transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));

        yield return new WaitForSeconds(beforeShoot);

        for (int i = 0; i < shootCicles; i++)
        {
            SFBComp.Shoot(1);
            yield return new WaitForSeconds(shootFor);
        }

        transform.position = target.transform.position + new Vector3(0, -5, 0);

        yield return new WaitForSeconds(hideFor);
        colliderComp.enabled = false;
        StartCoroutine(wait());
    }
}
