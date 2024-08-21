using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PickUpsData", menuName = "PickUps/PickUpsData")]
public class PickUpsData : ScriptableObject
{
    public List<GameObject> PickUpsTypeList;
}
