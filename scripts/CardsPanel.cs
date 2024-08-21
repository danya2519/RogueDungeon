using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsPanel : MonoBehaviour
{
    public static CardsPanel Instance { get; private set; }

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
        if (currentItem != null)
        {
            Destroy(currentItem);
        }
        currentItem = Instantiate(cellPrefab, transform);
        
    }
}
