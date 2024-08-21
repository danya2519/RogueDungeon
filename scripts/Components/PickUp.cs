using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private HeartType heartType;
    [SerializeField] private GameObject parent;

    int heartIndex;

    private void Start()
    {
        switch (heartType)
        {
            case HeartType.Simple:
                heartIndex = 0;
                break;
            case HeartType.Cursed:
                heartIndex = 1;
                break;
            case HeartType.Tropic:
                heartIndex = 2;
                break;
            case HeartType.Lava:
                heartIndex = 3;
                break;
            case HeartType.Polluted:
                heartIndex = 4;
                break;
            case HeartType.Angel:
                heartIndex = 5;
                break;
            case HeartType.Devil:
                heartIndex = 6;
                break;
            case HeartType.Magic:
                heartIndex = 7;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && HealthBar.Instance.heartContainerList.Count > HealthBar.Instance.heartList.Count)
        {
            HealthBar.Instance.AddHeart(heartIndex);
            Destroy(gameObject);
        }
    }
}
