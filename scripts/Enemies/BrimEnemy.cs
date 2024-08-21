using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrimEnemy : MonoBehaviour
{
    private GameObject target;
    [SerializeField] private GameObject brimstone;
    [SerializeField] private GameObject head;
    [SerializeField] private GameObject headOrigin;
    [SerializeField] private float speed;
    private Rigidbody rigidbodyComp;
    

    void Start()
    {
        target = GameObject.FindWithTag("Player");
        rigidbodyComp = GetComponent<Rigidbody>();
        StartCoroutine(wait());
    }
    void Update()
    {
        if (brimstone.activeSelf)
        {
            if (Physics.Raycast(head.transform.position, head.transform.forward, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out HealthBar playerHealth))
                {
                    playerHealth.RemoveHeart();
                }
            }
        }
        head.transform.position = headOrigin.transform.position; 
        transform.LookAt(new Vector3(target.transform.position.x, target.transform.position.y + 1, target.transform.position.z));
        transform.Rotate(0.0f, 180, 0.0f, Space.Self);
        rigidbodyComp.velocity = transform.forward * speed;
    }
    IEnumerator wait()
    {
        brimstone.SetActive(false);
        yield return new WaitForSeconds(2);
        brimstone.SetActive(true);
        yield return new WaitForSeconds(2);
        StartCoroutine(wait());
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.TryGetComponent(out HealthBar playerHealth))
            {
                playerHealth.RemoveHeart();
            }
        }
    }*/
}
