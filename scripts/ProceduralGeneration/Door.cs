using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private float radius;
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private bool IsSpecialDoor = false;
    private Animator animator;

    void Start()
    {
        if (!IsSpecialDoor)
        {
            CheckOverlaps();
            animator = GetComponent<Animator>();
            DoorSystem.Instance.OnNewRoomEntered += CLoseDoor;
        }
    }

    public void CheckOverlaps()
    {
        Collider[] objectColisions = Physics.OverlapSphere(transform.position, radius);
        List<Door> doorColisions = new List<Door>();
        foreach (var item in objectColisions)
        {
            if(item.transform.TryGetComponent(out Door door))
            {
                doorColisions.Add(door);
            }
        }
        if(doorColisions.Count <= 1)
        {
            
            GameObject spawnedWall = Instantiate(wallPrefab, transform.position, transform.rotation);
            spawnedWall.transform.SetParent(transform.GetComponentInParent<Room>().transform);
            Destroy(gameObject);
        }
        else
        {
            if (doorColisions[1].IsSpecialDoor == false)
            {
                TextMeshPro spawnedText = Instantiate(text, doorColisions[doorColisions.Count - 1].transform.position, Quaternion.identity).GetComponent<TextMeshPro>();
                string colisions = " ";
                foreach (var item in doorColisions)
                {
                    colisions += "    " + item.name;
                }
                spawnedText.text = colisions;

                Destroy(doorColisions[doorColisions.Count - 1]);
            }
        }
    }

    internal void SetLockState(bool lockState)
    {
        animator.SetBool("IsClosed", lockState);
    }

    public void CLoseDoor()
    {
        SetLockState(true);
    }

    public void OpenDoor()
    {
        SetLockState(false);
    }
}
