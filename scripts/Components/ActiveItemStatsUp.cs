using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class ActiveItemStatsUp : MonoBehaviour
{
    private GameObject player;

    [SerializeField] private RoomItemPoolSO itemData;

    private int itemIndex;
    
    private int currentCharge;

    [SerializeField] private Image bar;

    public void StatsUpSetup(int id, RoomItemPoolSO itemData)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        itemIndex = id;
        currentCharge = itemData.roomItems[itemIndex].charge;
        this.itemData = itemData;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && itemData.roomItems[itemIndex].charge <= currentCharge) 
        {
            UseItem();
        }
        if (itemData.roomItems[itemIndex].charge != 0)
        {
            bar.fillAmount = (float)currentCharge / itemData.roomItems[itemIndex].charge;
        }
        else
        {
            bar.fillAmount = 1;
        }
            
        if (Input.GetKeyDown(KeyCode.L))
        {
            ChargeUp();
        }
        
    }

    public void UseItem()
    {
        if(itemData.roomItems[itemIndex].charge <= currentCharge)
        {
            currentCharge = 0;
            Instantiate(itemData.roomItems[itemIndex].sFX, player.transform.position, Quaternion.identity);
        }
    }


    public void ChargeUp()
    {
        currentCharge++;
    }

}
