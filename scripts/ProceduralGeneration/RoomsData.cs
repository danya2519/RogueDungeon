using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomsData", menuName = "RandomGeneration/RoomsData")]
public class RoomsData : ScriptableObject 
{
    public List<GameObject> rooms = new List<GameObject>();
}

