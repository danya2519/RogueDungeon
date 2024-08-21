using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.AxisState;

public class LookAtMouse : MonoBehaviour
{
    [SerializeField] private LayerMask shootMask;
    private FixedJoystick joystick;

    private void Start()
    {
        if (ES3.Load<bool>("isJoy"))
        {
            joystick = GameObject.FindGameObjectWithTag("RightJoystick").GetComponent<FixedJoystick>();
        }
    }

    void Update()
    {
        if (!ES3.Load<bool>("isJoy"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, shootMask))
            {
                transform.LookAt(raycastHit.point);

            }
        }
        else
        {
            if(joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                Vector3 moveVector = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
                transform.rotation = Quaternion.LookRotation(moveVector, Vector3.up);
            }
        }
    }
}
