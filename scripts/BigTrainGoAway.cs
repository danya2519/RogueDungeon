using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTrainGoAway : MonoBehaviour
{
    [SerializeField] private GameObject trainPart;
    [SerializeField] private GameObject SFX;
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(SFX, transform.position, transform.rotation);
            trainPart.GetComponent<GoForward>().enabled = true;
            trainPart.GetComponent<WaitDestroy>().enabled = true;
            Destroy(gameObject);
        }
    }
}
