using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemsContainer : MonoBehaviour
{
    public static ItemsContainer Instance { get; private set; }

    private List<ItemSaveData> itemsToSave = new List<ItemSaveData>();

    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private PoolsSO roomPool;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There are more than one ItemsContainer " + gameObject.name);
        }
        Instance = this;
    }

   

  
    
       
    

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            ES3.Save<List<ItemSaveData>>("ItemContainerItems", new List<ItemSaveData>());
        }


        SceneManager.activeSceneChanged += Save;
        List <ItemSaveData> savedItems = ES3.Load<List<ItemSaveData>>("ItemContainerItems");
        if (savedItems != null)
        {
            foreach (ItemSaveData item in savedItems)
            {
                AddItem(item.id, item.roomItemDataIndex);
            }
        }
    }

    void Save(Scene arg0, Scene arg1)
    {
        ES3.Save<List<ItemSaveData>>("ItemContainerItems", itemsToSave);
    }

    public PoolsSO GetMainPool()
    {
        return roomPool;
    }

    public void AddItem(int id, int roomItemDataIndex)
    {
        itemsToSave.Add(new ItemSaveData(id, roomItemDataIndex));
        GameObject spawnedItem = Instantiate(cellPrefab, transform);
        ItemStatsUp spawnedItemStatsUp = spawnedItem.AddComponent<ItemStatsUp>();
        spawnedItemStatsUp.StatsUpSetup(id, roomPool.roomPools[roomItemDataIndex]);
        spawnedItem.GetComponent<Image>().sprite = roomPool.roomPools[roomItemDataIndex].roomItems[id].itemIcon;
    }
}

    public class ItemSaveData
{
    public int id;
    public int roomItemDataIndex;

    public ItemSaveData(int id, int roomItemDataIndex)
    {
        this.id = id;
        this.roomItemDataIndex = roomItemDataIndex;
    }
}
