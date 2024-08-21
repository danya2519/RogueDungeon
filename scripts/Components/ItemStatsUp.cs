using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemStatsUp : MonoBehaviour
{
    private GameObject player;

    [SerializeField] private Achivments achivments;
    [SerializeField] private GameObject rockPrefab;
    [SerializeField] private RoomItemPoolSO itemData;

    private int itemIndex;


    private void Start()
    {

    }

    public void StatsUpSetup(int id, RoomItemPoolSO itemData)
    {
        itemIndex = id;
        this.itemData = itemData;
        player = GameObject.FindGameObjectWithTag("Player");
        CharacterControllerC.speedMove += itemData.roomItems[itemIndex].speed;
        Attack.damage += itemData.roomItems[itemIndex].damage;
        Attack.shootSpeed += itemData.roomItems[itemIndex].shotSpeed;
        print(Attack.shootSpeed);
        print(itemData.roomItems[itemIndex].shotSpeed);
        Attack.speed += itemData.roomItems[itemIndex].bulletSpeed;
        if (itemData.roomItems[itemIndex].projectile != null)
        {
            Attack.projectile = itemData.roomItems[itemIndex].projectile;
        }
        if(itemData.roomItems[itemIndex].shootTime != 0)
        {
            StartCoroutine(Wait());

        }
        if (itemData.roomItems[itemIndex].bullet)
        {
            HealthBar.Instance.onPlayerTakeDamage += OnDamageTake;
        }
        if(itemData.roomItems[itemIndex].containers > 0)
        {
            for (int i = 0; i < itemData.roomItems[itemIndex].containers; i++)
            {
                player.GetComponent<HealthBar>().AddConteiner();
            }
        }
        else if(itemData.roomItems[itemIndex].containers < 0)
        {
            for (int i = 0; i < itemData.roomItems[itemIndex].containers * -1; i++)
            {
                if(player.GetComponent<HealthBar>().TryRemoveConteiner());
            }
        }
        if (itemData.roomItems[itemIndex].scale != 0)
        {
            player.transform.localScale += new Vector3(itemData.roomItems[itemIndex].scale, itemData.roomItems[itemIndex].scale, itemData.roomItems[itemIndex].scale);
        }
        if (itemData.roomItems[itemIndex].damageMultiplier != 0)
        {
            Attack.damage = Mathf.RoundToInt(Attack.damage * itemData.roomItems[itemIndex].damageMultiplier);
        }
        if (itemData.roomItems[itemIndex].shotSpeedMultiplier != 0)
        {
            Attack.shootSpeed *= itemData.roomItems[itemIndex].shotSpeedMultiplier;
        }
        if (itemData.roomItems[itemIndex].scaleMultiplier != 0)
        {
            player.transform.localScale *= itemData.roomItems[itemIndex].scaleMultiplier;
        }
        if (itemData.roomItems[itemIndex].baby != null)
        {
            Instantiate(itemData.roomItems[itemIndex].baby, player.transform.position + new Vector3(0, 0, -1), Quaternion.identity);
        }
    }

    private void OnDamageTake()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(itemData.roomItems[itemIndex].bullet, player.transform.position + new Vector3(0,1,0), player.transform.rotation);
        }

    }

    private void ChangePlayerBullet()
    {
        Attack.projectile = itemData.roomItems[itemIndex].projectile;
    }



    private IEnumerator Wait()
    {

        yield return new WaitForSeconds(itemData.roomItems[itemIndex].shootTime);
        print(itemData.roomItems[itemIndex].bullet.name);
        Instantiate(itemData.roomItems[itemIndex].bullet, player.transform.position, player.transform.rotation);
        StartCoroutine(Wait());
        ;
    }


    
}
