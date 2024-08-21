using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float gravityScale;

    private CharacterController controller;
    private Animator animator;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveVector = new Vector3(x, 0, z);
        Vector3 gravityVector = new Vector3(0,gravityScale, z);

        if (moveVector != Vector3.zero)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Lifting");
        }

        transform.forward = moveVector;
        
        controller.Move(moveVector * speed * Time.deltaTime);
        controller.Move(gravityVector * speed * Time.deltaTime);
    }
}

