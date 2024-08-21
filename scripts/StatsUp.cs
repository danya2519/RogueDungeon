using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsUp : MonoBehaviour
{
    
    private int itemID;
    private PoolsSO poolsData;
    private RoomItemPoolSO pool;
    private int poolIndex;

    private void Start()
    {
        poolsData = ItemsContainer.Instance.GetMainPool();
        pool = poolsData.roomPools[poolIndex];
    }

    private void PickUp()
    {
        if (pool.roomItems[itemID].isActive == false)
        {
            ItemsContainer.Instance.AddItem(itemID, poolIndex);
        }
        else
        {
            ActiveItemsContainer.Instance.ReplaceItem(itemID, pool);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CharacterControllerC character))
        {
            PickUp();
            Destroy(gameObject);
        }
    }

    public void SetItemId(int id, int roomItemDataIdnex)
    {
        itemID = id;
        poolIndex = roomItemDataIdnex;
    }
}
