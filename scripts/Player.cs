using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float gravity;

    private CharacterController controller;
    private Animator animator;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        


        Vector3 moveVector = new Vector3(xAxis, 0, zAxis);

        Vector3 gravityVector = new Vector3(0, gravity, 0);

        controller.Move(gravityVector);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(moveVector * speed * 2 * Time.deltaTime);
        }
        else
        {
            controller.Move(moveVector * speed * Time.deltaTime);
        }


        if (Input.GetKeyDown(KeyCode.G))
        {
            animator.SetTrigger("Dance");
        }

        if (moveVector != Vector3.zero)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        transform.forward = moveVector;
    }

}
