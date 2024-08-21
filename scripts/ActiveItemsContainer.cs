using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveItemsContainer : MonoBehaviour
{
    public static ActiveItemsContainer Instance { get; private set; }

    private GameObject currentItem;

    [SerializeField] private GameObject cellPrefab;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There are more than one ItemsContainer " + gameObject.name);
        }
        Instance = this;
    }

    public void ReplaceItem(int id, RoomItemPoolSO roomItemData)
    {
        if(currentItem !=  null)
        {
            Destroy(currentItem);
        }
        currentItem = Instantiate(cellPrefab, transform);
        ActiveItemStatsUp spawnedItemStatsUp = currentItem.GetComponent<ActiveItemStatsUp>();
        spawnedItemStatsUp.StatsUpSetup(id, roomItemData);
        currentItem.GetComponent<Image>().sprite = roomItemData.roomItems[id].itemIcon;
    }
}
