using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteIfNotOpened : MonoBehaviour
{
    [SerializeField] private Achivments achivments;
    [SerializeField] private int Id;
    [SerializeField] private GameObject replace;
    void Start()
    {
        if (!ES3.Load<bool>(achivments.Achivment[Id].name, false) && replace == null)
        {
            Destroy(gameObject);
        }
        else if(!ES3.Load<bool>(achivments.Achivment[Id].name, false))
        {
            Instantiate(replace, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
