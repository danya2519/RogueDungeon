using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    private BoxCollider boxCollider;
    private SphereCollider spereCollider;
    [SerializeField] private int value;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        spereCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && CKBMeneger.coins >= value)
        {
            CKBMeneger.coins -= value;
            boxCollider.enabled = false;
            spereCollider.enabled = false;
        }
    }
}
