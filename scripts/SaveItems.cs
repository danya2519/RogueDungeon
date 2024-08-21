using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveItems : MonoBehaviour
{
    [SerializeField] private bool isFirstLevel;
    private int currentChildCount;
    void Start()
    {
        StartCoroutine(Wait1());
        if (!isFirstLevel)
        {
            List<GameObject> list = ES3.Load("Items", new List<GameObject>());
            foreach (GameObject item in list)
            {
                Instantiate(item, transform);
                print(item);
            }
        }
    }

    private IEnumerator Wait1()
    {
        yield return new WaitForSeconds(5);
        if(transform.childCount > currentChildCount)
        {
            print(transform.childCount);
            foreach (Transform item in transform)
            {
                List<GameObject> list = ES3.Load("Items", new List<GameObject>());
                list.Add(item.gameObject);
                ES3.Save<List<GameObject>>("Items", list);
                currentChildCount = list.Count;
            }
            print(ES3.Load("Items", new List<GameObject>()));
        }
        StartCoroutine(Wait1());
    }
}
