using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int loopRagdolls = 1;
    [SerializeField] private GameObject ragdoll;


    public int GetHealth()
    {
        return health;
    }

    public void ChangeHealth(int value)
    {

        health += value; 
        if(health <= 0)
        {
            for (int i = 0; i < loopRagdolls; i++)
            {
                Instantiate(ragdoll, transform.position, transform.rotation);
            }
            Destroy(gameObject);

        }
    }
    

}
