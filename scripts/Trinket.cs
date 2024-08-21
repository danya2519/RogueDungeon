using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trinket : MonoBehaviour
{
    [SerializeField] private int ID;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("TrinletsPanel").GetComponent<TrinketsPanel>().PutTrincket(ID);
        }
    }
}
