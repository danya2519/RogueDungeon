using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ShootRandomChanceBullets : MonoBehaviour
{
    
    [SerializeField] private Chanse[] chanses;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float shootInTime;

    void OnEnable()
    {
        StartCoroutine(wait());
    }

    private GameObject ChooseRandomBullet()
    {
        int randomNumber = Random.Range(1, 101);

        for (int i = 0; i < chanses.Length; i++)
        {
            if (randomNumber > chanses[i].min && randomNumber <= chanses[i].max)
            {
                return chanses[i].bulletPrefab;
            }
            
        }
        Debug.LogError("Problem with bullet chances     " + randomNumber);
        return null;
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(shootInTime);
        Instantiate(ChooseRandomBullet(), transform.position + offset, transform.rotation);
        StartCoroutine(wait());
    }
}

[System.Serializable]
public class Chanse
{
    public int min;
    public int max;
    public GameObject bulletPrefab;
}
