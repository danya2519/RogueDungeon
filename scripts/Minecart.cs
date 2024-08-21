using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minecart : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool didWorked;
    private void Start()
    {
        didWorked = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !didWorked)
        {
            didWorked = true;
            animator.SetBool("Go", true);
        }
    }

}
