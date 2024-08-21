using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    [SerializeField] private Vector3 shakeForceVector;
    [SerializeField] private float shakeForce;
    [SerializeField] private float returnForce;
    [SerializeField] private float shakeCD;

    Vector3 startPosition;
    Vector3 currentPosition;
    Vector3 targetPosition;

    private void Start()
    {
        StartCoroutine(Shaking());
        startPosition = transform.position;
    }

    void Update()
    {
        /*targetPosition = Vector3.Lerp(targetPosition, startPosition, returnForce * Time.deltaTime);*/
        targetPosition = Vector3.Slerp(targetPosition, Vector3.zero, shakeForce * Time.deltaTime);
        currentPosition = Vector3.Slerp(currentPosition, targetPosition, shakeForce * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, startPosition, returnForce * Time.deltaTime);
    }

    private IEnumerator Shaking()
    {
        yield return new WaitForSeconds(shakeCD);
        targetPosition +=  new Vector3(Random.Range(-shakeForceVector.x, shakeForceVector.x), Random.Range(-shakeForceVector.y, shakeForceVector.y), Random.Range(-shakeForceVector.z, shakeForceVector.z));
        transform.position += currentPosition;
       
        StartCoroutine(Shaking());
        
    }
}
