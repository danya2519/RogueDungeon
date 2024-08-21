using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestText : MonoBehaviour
{
    [SerializeField] private string text;

    private void Start()
    {
        GameObject.FindGameObjectWithTag("MainText").GetComponent<MainText>().PrintOnScreen(text);
    }
}
