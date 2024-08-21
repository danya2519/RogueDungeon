using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainDoor : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private Animator animator;
    private void Start()
    {
        animator= GetComponent<Animator>();
    }
    void Update()
    {
        if( target == null)
        {
            animator.SetBool("Open", true);
            Destroy(gameObject, 2.25f);
        }
        
    }
}
