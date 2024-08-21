using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnWallTouch : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private int loopTimes = 1;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 6)
        {
            //print(collision.gameObject);
            for (int i = 0; i < loopTimes; i++)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
