using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeMachine : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject itemTable;
    [SerializeField] private PickUpsData PickUpsData;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OpenDoor()
    {
        if (CKBMeneger.coins > 0)
        {
            CKBMeneger.coins--;
            if(Random.Range(1,10) < 3)
            {
                StartCoroutine(Wait());
            }
            else if((Random.Range(1, 10) < 1))
            {
                StartCoroutine(Wait1());
            }
            animator.SetTrigger("Play");
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OpenDoor();
        }
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.5f);
        Instantiate(PickUpsData.PickUpsTypeList[Random.Range(0, PickUpsData.PickUpsTypeList.Count)], spawnPoint.position, Quaternion.identity);
    }
    private IEnumerator Wait1()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Instantiate(itemTable, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
