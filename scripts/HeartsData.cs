using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HeartsData", menuName = "Hearts/HeartsData")]
public class HeartsData : ScriptableObject
{
    public List<GameObject> heartTypeList;
}
