using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PoolData", menuName = "ItemPool/PoolData")]
public class PoolsSO : ScriptableObject
{
    public List<RoomItemPoolSO> roomPools;
}