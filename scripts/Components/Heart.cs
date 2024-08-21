using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
  

    

    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private float shotSpeed;
    [SerializeField] private float bulletSpeed;

    [SerializeField] private GameObject desroyFx;
    [SerializeField] private int loopObject = 1;

    private int heartIndex;

    private void Start()
    {
        StatsUp();
   

    }

    private GameObject GetPlayer()
    {
        return GameObject.FindGameObjectWithTag("Player");
    }

    public void StatsUp()
    {
        CharacterControllerC.speedMove += speed;
        Attack.damage += damage;
        Attack.shootSpeed += shotSpeed;
        Attack.speed += bulletSpeed;
    }

    public void StatsDown() 
    {
        CharacterControllerC.speedMove -= speed;
        Attack.damage -= damage;
        Attack.shootSpeed -= shotSpeed;
        Attack.speed -= bulletSpeed;
    }
    
    public void OnDestroy()
    {
        StatsDown();
        for (int i = 0; i < loopObject; i++)
        {
            Instantiate(desroyFx, PlayerManager.GetPlayer().transform.position + transform.up, Quaternion.identity);
        }
    }
}
