using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Net.Mime.MediaTypeNames;

public class MainText : MonoBehaviour
{
    static TextMeshProUGUI TMP;
    private float timer;
    private bool reset;
    private bool printing;
    private string curentText;
    void Start()
    {
        TMP = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (printing)
        {
            TMP.text = curentText;
            printing = false;
        }
        if(reset == true && timer > 5f)
        {
            TMP.text = "";
            reset = false;
        }
    }

    public void PrintOnScreen(string text)
    {
        timer = 0;
        curentText = text;
        reset = true;
        printing =true;
    }

}
