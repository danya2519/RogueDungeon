using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemiesOf")]
public class EnemyDatas : ScriptableObject
{
    public List<EnemyData> enemyDataList = new();
}

[System.Serializable]
public class EnemyData
{
    public GameObject enemyPrefab;

}
