using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool didWorked;
    private GameObject water;
    [SerializeField] private float speed;
    private void Start()
    {
        didWorked = false;
        water = GameObject.FindGameObjectWithTag("water");
    }

    private void Update()
    {
        if(didWorked && water.active == true)
        {
            water.transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !didWorked)
        {
            animator.SetBool("Rotate", true);
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        didWorked = true;
        yield return new WaitForSeconds(5f);
        water.SetActive(false);
    }
}
