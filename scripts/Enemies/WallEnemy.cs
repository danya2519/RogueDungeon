using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Rotate;

public class WallEnemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int directions;
    [SerializeField] private GameObject Compas;
    private GameObject target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        directions = Random.Range(0,3);
        transform.Rotate(0, directions * 90, 0);
    }

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        if(Compas.transform.rotation.y != 0)
        {
            if (Compas.transform.rotation.y > 0)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
        else
        {

        }

    }
}
