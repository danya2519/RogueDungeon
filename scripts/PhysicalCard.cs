using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalCard : MonoBehaviour
{
    [SerializeField] private int id;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("CardsObj").GetComponent<CardOrPills>().PlaceCard(id);
            Destroy(gameObject);
        }
    }
}
