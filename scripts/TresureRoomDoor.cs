using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TresureRoomDoor : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OpenDoor()
    {
        if (CKBMeneger.keys > 0)
        {
            CKBMeneger.keys--;
            animator.SetBool("Open", true);
            Destroy(gameObject, 3f);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OpenDoor();
        }
    }
}
