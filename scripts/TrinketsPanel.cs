using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrinketsPanel : MonoBehaviour
{
    [SerializeField] private CardsData cardsSo;
    private Image imageComp;
    private GameObject currentTrinket;
    void Start()
    {
        imageComp = GetComponent<Image>();
        imageComp.color = Color.clear;
    }

    public void PutTrincket(int id)
    {
        if (currentTrinket == null)
        {
            imageComp.sprite = cardsSo.Cards[id].itemIcon;
            imageComp.color = Color.white;
            currentTrinket = Instantiate(cardsSo.Cards[id].itemPrefab);
        }
        else
        {
            Destroy(currentTrinket);
            PutTrincket(id);
        }
    }
}
