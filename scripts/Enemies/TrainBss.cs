using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainBss : MonoBehaviour
{
    [SerializeField] private GameObject flame;
    [SerializeField] private GameObject gas;

    private void Start()
    {
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        flame.SetActive(false);
        gas.SetActive(false);
        yield return new WaitForSeconds(1);
        if(Random.Range(1,5) == 1)
        {
            gas.SetActive(true);
            yield return new WaitForSeconds(3);
            flame.SetActive(true);
            gas.SetActive(false);
            yield return new WaitForSeconds(2);
        }
        else
        {
            yield return new WaitForSeconds(5);
        }

        StartCoroutine(wait());
    }
}
