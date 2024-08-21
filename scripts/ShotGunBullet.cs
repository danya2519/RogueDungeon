using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunBullet : MonoBehaviour
{
    void Start()
    {
        transform.eulerAngles += new Vector3(Random.Range(-15, 15), Random.Range(-15, 15), 0);
    }
}
