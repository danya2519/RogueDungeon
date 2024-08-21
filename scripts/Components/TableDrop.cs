using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TableDrop : MonoBehaviour
{
    public int poolDataIndex;


    private static List<int> itemIndexList = new List<int>();

    [SerializeField] private Transform spawnPoint;

    [SerializeField] private Achivments achivments;

    private static List<int> spawnedItemsIndexList = new();

    private PoolsSO poolData;

    private RoomItemPoolSO roomItems;

    private void Start()
    {
        poolData = ItemsContainer.Instance.GetMainPool();
        roomItems = poolData.roomPools[poolDataIndex];
        if (itemIndexList.Count <= 0)
        {
            for (int i = 0; i < roomItems.roomItems.Count; i++)
            {
                itemIndexList.Add(i);
            }
        }
        SpawnRandomItem();

    }

    private void SpawnRandomItem()
    {
        int randomIndex = Random.Range(0, itemIndexList.Count);
        int itemId = itemIndexList[randomIndex];
        int repeatCount = 0;
        while (spawnedItemsIndexList.Contains(itemId) && repeatCount < 15)
        {
            repeatCount++;
            itemId = Random.Range(0, roomItems.roomItems.Count);
            if (spawnedItemsIndexList.Count >= roomItems.roomItems.Count)
            {
                spawnedItemsIndexList.Clear();
                Debug.LogError("All StatsUp has already taken");
                /*break;*/
                    
            }
        }
        if (roomItems.roomItems[itemId].achivmentId != 0)
        {
            if (!ES3.Load<bool>(achivments.Achivment[roomItems.roomItems[itemId].achivmentId].name, false))
            {
                itemIndexList.Remove(randomIndex);
                print(achivments.Achivment[roomItems.roomItems[itemId].achivmentId].name + " was deleted");
                SpawnRandomItem();
                return;
            }
            else
            {
                spawnedItemsIndexList.Add(itemId);
                GameObject randomRoomItem = roomItems.roomItems[itemId].itemPrefab;
                GameObject spawnedPickup = Instantiate(randomRoomItem, spawnPoint.position, Quaternion.identity);
                spawnedPickup.AddComponent<StatsUp>().SetItemId(itemId, poolDataIndex);
            }
        }
        else
        {
            spawnedItemsIndexList.Add(itemId);
            GameObject randomRoomItem = roomItems.roomItems[itemId].itemPrefab;
            GameObject spawnedPickup = Instantiate(randomRoomItem, spawnPoint.position, Quaternion.identity);
            spawnedPickup.AddComponent<StatsUp>().SetItemId(itemId, poolDataIndex);
        }


        itemIndexList.Remove(randomIndex);



    }
}
