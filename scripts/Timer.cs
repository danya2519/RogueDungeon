using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float timer = 0;
    private TextMeshProUGUI TMP;
    void Start()
    {
        TMP = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        TMP.text = Mathf.Round(106 - timer).ToString();
    }
}
