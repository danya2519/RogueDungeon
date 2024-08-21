using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSystem : MonoBehaviour
{
    public static DoorSystem Instance { get; private set; }

    public event Action OnNewRoomEntered;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("There are more than one door system");
        }
        Instance = this;
    }

    public void Fire_OnNewRoomEntered()
    {
        OnNewRoomEntered?.Invoke();
    }
}
