using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableBosses : MonoBehaviour
{
    [SerializeField] private GameObject[] bosses;
    private bool worked = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !worked)
        {
            foreach(GameObject go in bosses)
            {
                go.SetActive(true);
            }
            worked = true;
        }
    }
}
