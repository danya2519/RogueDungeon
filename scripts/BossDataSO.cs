using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossDataSO")]
public class BossDataSO : ScriptableObject
{
    public List<BossData> bossDataList = new();
}

[System.Serializable]
public class BossData 
{
    public GameObject roomPrefab;
  
}
