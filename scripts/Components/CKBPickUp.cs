using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CKBPickUp : MonoBehaviour
{
    [SerializeField] private PickUpType pickUpType;
    [SerializeField] private int amount;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (pickUpType)
            {
                case PickUpType.Coin:
                    CKBMeneger.coins += amount;
                    Destroy(gameObject);
                    break;
                case PickUpType.Key:
                    CKBMeneger.keys += amount;
                    Destroy(gameObject);
                    break;
                case PickUpType.Bomb:
                    CKBMeneger.bombs += amount;
                    Destroy(gameObject);
                    break;
                default:
                    Destroy(gameObject);
                    break;
            }
        }
    }


    public enum PickUpType { Coin, Key, Bomb }
}


