using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpecialRoomS", menuName = "Item/Room")]
public class SpecialRoomsProbabylitiesSO : ScriptableObject
{
    public List<SpecialRoom> SpecialRoomsList;
}

[System.Serializable]
public class SpecialRoom
{
    public string name;
    public int probabylity;
    public GameObject prefab;

}