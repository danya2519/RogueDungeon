using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToNearestEnemy : MonoBehaviour
{
    void Start()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in enemies)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        transform.position = tMin.transform.position;
    }

}
