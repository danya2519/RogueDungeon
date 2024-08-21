using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Error : MonoBehaviour
{
    [SerializeField] private RoomItemPoolSO[] pools;
    void Awake()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("ItemTable"))
        {
            item.GetComponent<TableDrop>().poolDataIndex = Random.Range(0, pools.Length);
        }
    }
}
