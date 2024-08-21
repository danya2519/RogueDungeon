using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardsData", menuName = "CardsPool/CardPool")]
public class CardsData : ScriptableObject
{
    public List<Card> Cards;
}

[System.Serializable]
public class Card
{
    public string name;
    public GameObject itemPrefab;

    public Sprite itemIcon;
    public GameObject CardPrefab;



}