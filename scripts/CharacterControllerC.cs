using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerC : MonoBehaviour
{
    public static float speedMove;
    public float jumpHeight;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private float fallSpeed;
    private FixedJoystick joystick;

    private float gravityForce;
    private Vector3 moveVector;

    private Animator animator;
    private CharacterController characterController;
    
    private void Start()
    {
        if (ES3.Load<bool>("isJoy"))
        {
            joystick = GameObject.FindGameObjectWithTag("LeftJoystick").GetComponent<FixedJoystick>();
            print(joystick);
        }
        characterController = GetComponent<CharacterController>();
        animator = player.GetComponent<Animator>();
    }
    private void Update()
    {
        Gravity();
        CharacterMove();
    }
    private void CharacterMove()
    {
        if (Vector3.Angle(Vector3.forward, moveVector)> 1f || Vector3.Angle(Vector3.forward ,moveVector) == 0f)
        {
            /*Vector3 direction = Vector3.RotateTowards(transform.forward, moveVector, speedMove, 0.0f);
            if (direction != Vector3.zero)
            {
                player.transform.rotation = Quaternion.LookRotation(direction);
            }*/

            Vector3 lookVector = Vector3.RotateTowards(player.transform.forward, moveVector, speedMove, 0.0f);
            lookVector.y = 0;
            if (lookVector != Vector3.zero)
            {

            player.transform.rotation = Quaternion.RotateTowards
                (
                    player.transform.rotation,
                    Quaternion.LookRotation(lookVector, Vector3.up),
                    180f * Time.deltaTime
                );

            }

        }
      

        

        moveVector = Vector3.zero;
        if (!ES3.Load<bool>("isJoy"))
        {
            animator.SetBool("Run", Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0);
            moveVector.x = Input.GetAxis("Horizontal");

            moveVector.z = Input.GetAxis("Vertical");
        }
        else
        {
            
            animator.SetBool("Run", joystick.Horizontal != 0 || joystick.Vertical != 0);
            moveVector.x = joystick.Horizontal;

            moveVector.z = joystick.Vertical;
        }

        Vector3 gravityVector = new Vector3(0, gravityForce, 0);
        characterController.Move(moveVector * speedMove* Time.deltaTime);
        characterController.Move(gravityVector * Time.deltaTime);
    }
    private void Gravity()
    {
        if (Physics.OverlapSphere(groundCheck.position, groundCheckRadius).Length > 1)
        {
            gravityForce -= fallSpeed * Time.deltaTime;
        }
        else
        {
            gravityForce = -1f;
        }
    }
}
