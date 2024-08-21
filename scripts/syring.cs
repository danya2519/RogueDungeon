using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class syring : MonoBehaviour
{
    private int Id;
    [SerializeField] private Image imageComp;
    void Start()
    {
        Id = Random.Range(0,9);
        imageComp.sprite = syringMengher.imagesForSyringe[Id];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("CardsObj").GetComponent<CardOrPills>().PlaceSyringe(syringMengher.imagesForSyringe[Id], syringMengher.effectsOfSyringes[Id], gameObject);
            Destroy(gameObject);
        }
    }
}
