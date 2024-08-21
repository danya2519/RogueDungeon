using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CKBtext : MonoBehaviour
{
    private TextMeshProUGUI TMP;
    [SerializeField] private PickUpType pickUpType;
    void Start()
    {
        TMP = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {


        switch (pickUpType)
        {
            case PickUpType.Coin:
                TMP.text = CKBMeneger.coins.ToString();
                break;
            case PickUpType.Key:
                TMP.text = CKBMeneger.keys.ToString();
                break;
            case PickUpType.Bomb:
                TMP.text = CKBMeneger.bombs.ToString();
                break;
            default:
                break;

        }
    }

    public enum PickUpType { Coin, Key, Bomb }
}
