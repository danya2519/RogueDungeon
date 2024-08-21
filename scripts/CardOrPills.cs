using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardOrPills : MonoBehaviour
{
    [SerializeField] private CardsData cardsSo;
    private Image imageComp;
    private int CurrentCardID;
    private GameObject uvText;
    private GameObject curentSyringe;
    private GameObject curentSyringeEffect;

    private void Start()
    {
        imageComp = GetComponent<Image>();
        uvText = GameObject.FindGameObjectWithTag("MainText");
        CurrentCardID = -1;
    }

    public void PlaceCard(int cardId)
    {
        imageComp.color = Color.white;
        if ((CurrentCardID != -1))
        {
            try
            {
                Instantiate(cardsSo.Cards[CurrentCardID].CardPrefab, GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(0, 0, 3), Quaternion.identity);
            }
            catch
            {

            }
        }
        CurrentCardID = cardId;
        imageComp.sprite = cardsSo.Cards[CurrentCardID].itemIcon;
    }

    public void PlaceSyringe(Sprite image, GameObject effect, GameObject self)
    {
        curentSyringe = self;
        curentSyringeEffect = effect;
        imageComp.color = Color.white;
        if ((CurrentCardID != -1))
        {
            Instantiate(cardsSo.Cards[CurrentCardID].CardPrefab, GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(0, 0, 3), Quaternion.identity);
        }
        CurrentCardID = 666;
        imageComp.sprite = image;
    }

    public void UseCard()
    {
        if(CurrentCardID != -1)
        {
            try
            {
                uvText.GetComponent<MainText>().PrintOnScreen(cardsSo.Cards[CurrentCardID].name);
                Instantiate(cardsSo.Cards[CurrentCardID].itemPrefab, GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(0, 0, 0), Quaternion.identity);
            }
            catch
            {
                uvText.GetComponent<MainText>().PrintOnScreen(curentSyringeEffect.name);
                Instantiate(curentSyringeEffect, GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(0, 0, 0), Quaternion.identity);

            }
            CurrentCardID = -1;
            imageComp.sprite = null;
            imageComp.color = Color.clear;
        }
    }
}
