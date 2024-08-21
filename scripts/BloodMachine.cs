using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodMachine : MonoBehaviour
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
    public void OpenDoor(GameObject player)
    {
        player.GetComponent<HealthBar>().RemoveHeart();
        if (Random.Range(1, 10) > 2)
        {
            StartCoroutine(Wait());
        }
        else
        {
            StartCoroutine(Wait1());
        }
        animator.SetTrigger("Go");

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OpenDoor(other.gameObject);
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
