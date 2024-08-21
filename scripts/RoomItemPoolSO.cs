using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomItemPool", menuName = "ItemPool/RoomItemPool")]
public class RoomItemPoolSO : ScriptableObject
{
    public List<RoomItem> roomItems;
}

[System.Serializable]
public class RoomItem
{
    public string name;
    public GameObject itemPrefab;

    public Sprite itemIcon;

    [Header("StatsUp")]
    public int damage;
    public float damageMultiplier;
    public float speed;
    public float shotSpeed;
    public float shotSpeedMultiplier;
    public float bulletSpeed;
    public int containers;
    public float scale;
    public float scaleMultiplier;

    [Header("BulletChange")]
    public GameObject projectile;

    [Header("PasiveShoot")]
    public GameObject bullet;
    public float shootTime;

    [Header("Activeitem")]
    public bool isActive;
    public int charge;
    public GameObject sFX;

    [Header("familiar")]
    public GameObject baby;

    [Header("Achivment")]
    public int achivmentId;



}
