using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : MonoBehaviour
{
    [SerializeField] private int DmgUp;
    [SerializeField] private float TearsUp;
    [SerializeField] private float SpeedUp;
    [SerializeField] private bool HpUp;
    [SerializeField] private float timeUp;
    [SerializeField] private float scaleMultiplierUp;

    void Start()
    {
        Attack.damage += DmgUp;
        Attack.shootSpeed += TearsUp;
        if (HpUp)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<HealthBar>().AddConteiner();
        }
        CharacterControllerC.speedMove += SpeedUp;
        Time.timeScale += timeUp;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().localScale *= scaleMultiplierUp;
    }
}
