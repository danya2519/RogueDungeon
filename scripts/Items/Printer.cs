using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Printer : MonoBehaviour
{
    private Animator animator;
    private bool Ischarging;
    [SerializeField] private PickUpsData PickUpsData;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(!Ischarging && GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            Ischarging = true;
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(20);
        animator.SetTrigger("Anim");
        yield return new WaitForSeconds(3);
        Instantiate(PickUpsData.PickUpsTypeList[Random.Range(0, PickUpsData.PickUpsTypeList.Count)], transform.position + Vector3.down, Quaternion.identity);
        Ischarging = false;
    }
}
