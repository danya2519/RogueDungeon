using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    private Vector3 targetScale;
    [SerializeField] private float force;
    [SerializeField] private float shakeCD;
    private void Start()
    {
        StartCoroutine(Shaking());
    }
    private IEnumerator Shaking()
    {
        yield return new WaitForSeconds(Random.Range(shakeCD, shakeCD + 0.25f));
        targetScale = new Vector3(Random.Range(0f, 2f), Random.Range(0f, 2f), Random.Range(0f, 2f));
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, force * Time.deltaTime);
        StartCoroutine(Shaking());
    }
}
