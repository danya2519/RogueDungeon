using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyDatas EnData;
    [SerializeField, Range(0, 100)] private int spawnChanse;
    private bool isActivated;

    private List<Transform> spawnPoints = new List<Transform>();

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out CharacterControllerC controller) && !isActivated)
        {
            isActivated = true;
            ActivateRoom();
            DoorSystem.Instance.Fire_OnNewRoomEntered();
        }
    }


    private void ActivateRoom()
    {
        foreach (Transform item in transform)
        {
            spawnPoints.Add(item);
            int spawnValue = Random.Range(0, 100);
            if (spawnValue <= spawnChanse)
            {
                SpawnRandomEnemy(item);
            }
        }
    }

    private void SpawnRandomEnemy(Transform parent)
    {
        int EnemyID = Random.Range(0, EnData.enemyDataList.Count);
        Instantiate(EnData.enemyDataList[EnemyID].enemyPrefab, parent.position, Quaternion.identity);
    }

    public bool GetActivatedState()
    {
        return isActivated;
    }

    public bool AllEnemiesIsDefeted()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length < 1;
    }
}
