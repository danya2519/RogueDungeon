using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BossBar : MonoBehaviour
{
    [SerializeField] private Image bar;
    [SerializeField] private HealthComponent HC;
    private int maxHealth;

    private void Start()
    {
        maxHealth = HC.GetHealth();
    }

    void Update()
    {
        bar.fillAmount = (float)HC.GetHealth() / maxHealth;
    }
}
