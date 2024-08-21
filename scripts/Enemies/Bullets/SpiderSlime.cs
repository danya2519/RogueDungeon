using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSlime : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool isTouched;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && CharacterControllerC.speedMove >= 2)
        {
            CharacterControllerC.speedMove -= speed;
            isTouched = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && CharacterControllerC.speedMove >= 2 && isTouched)
        {
            CharacterControllerC.speedMove += speed;
        }
    }

    private void OnDestroy()
    {
        if (isTouched)
        {
            CharacterControllerC.speedMove += speed;
        }
    }
}
