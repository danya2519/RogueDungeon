using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScriptToPlayerBullets : MonoBehaviour
{
    [SerializeField] private Behaviour doll;
    void Start()
    {
        
    }

/*    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.4f);
        var script = doll.GetComponents<MonoBehaviour>();
        GameObject[] Bullets = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject bullet in Bullets)
        {
            if(!collider.TryGetComponent<script>(out script healthComponent))
        }
        StartCoroutine(Wait());
    }*/
}
