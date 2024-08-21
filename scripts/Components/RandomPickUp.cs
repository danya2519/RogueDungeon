using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPickUp : MonoBehaviour
{
    [SerializeField] private PickUpsData PickUpsData;
    void Start()
    {
        Instantiate(PickUpsData.PickUpsTypeList[Random.Range(0, PickUpsData.PickUpsTypeList.Count)], transform.position, Quaternion.identity);
    }
}
