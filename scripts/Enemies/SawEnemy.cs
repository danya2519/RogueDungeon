using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawEnemy : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody rigidbodyComp;
    private GameObject target;
    private float rotY;
    private float rot;
    [SerializeField] private bool isGear = false;


    private void Start()
    {
        rigidbodyComp = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");
        if (isGear == false)
        {
            StartCoroutine(Wait());
        }
    }
    void Update()
    {
        rigidbodyComp.velocity = transform.forward * speed;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Boss")
        {
            //transform.forward = Vector3.zero;


            if(isGear)
            {
                transform.Rotate(0.0f, Random.Range(-30,30) - 90, 0.0f, Space.Self);
            }
            else
            {
                transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);
                ResetAngle();
            }
        }
        if (collision.gameObject.TryGetComponent(out HealthBar playerHealth))
        {
            playerHealth.RemoveHeart();
        }
        
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10);
        transform.LookAt(new Vector3(target.transform.position.x, transform.position.y ,target.transform.position.z));
        StartCoroutine(Wait());
    }

    private void ResetAngle()
    {        
        rot = Mathf.Round(transform.rotation.eulerAngles.y / 90);
        print(rot);
        transform.rotation = Quaternion.Euler(0, rot * 90, 0);
    }
}
