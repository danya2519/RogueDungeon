using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamiliarsMenager : MonoBehaviour
{
    [SerializeField] private bool isFirstFloor;
    public static List<GameObject> babies = new List<GameObject>();
    void Start()
    {
        if(!isFirstFloor)
        {
            foreach (GameObject item in babies)
            {
                Instantiate(item, new Vector3(0, 0, 0), Quaternion.identity);
            }
        }
        else
        {
            babies = new List<GameObject>();
        }
    }

    public void AddBaby(GameObject baby)
    {
        babies.Add(baby);
    }
}
