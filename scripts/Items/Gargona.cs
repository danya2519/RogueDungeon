using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargona : MonoBehaviour
{
    [SerializeField] private GameObject statue;
    void Start()
    {
        List<GameObject> list = new List<GameObject>();
        foreach (Collider obj in Physics.OverlapSphere(transform.position, 3f)) 
        {
            list.Add(obj.gameObject);
        }

        list.Remove(GameObject.FindGameObjectWithTag("Player"));

        foreach (GameObject item in list)
        {
            if(item.gameObject.tag != "Player")
            {
                if (item.TryGetComponent(out HealthComponent Health))
                {
                    if (Health.GetHealth() < 300)
                    {
                        Instantiate(statue, item.transform.position, Quaternion.identity);
                        Destroy(item);
                    }
                    else
                    {
                        Health.ChangeHealth(-150);
                    }
                }
            }
        }
    }

}
