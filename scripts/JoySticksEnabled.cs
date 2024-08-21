using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoySticksEnabled : MonoBehaviour
{
    void Start()
    {
        if (!ES3.KeyExists("isJoy"))
        {
            ES3.Save<bool>("isJoy", true);
        }
        gameObject.SetActive(ES3.Load<bool>("isJoy"));
    }
}
