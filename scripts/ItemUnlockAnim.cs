using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUnlockAnim : MonoBehaviour
{
    [SerializeField] private Achivments achivments;
    private Image imageComp;
    private Animator animComp;
    private float savedTime;
    private bool checkNow;

    private void Start()
    {
        imageComp = GetComponent<Image>();
        animComp = GetComponent<Animator>();
        imageComp.color = Color.clear;
    }

    public void UnlockAnim(int itemID)
    {
        imageComp.color = Color.white;
        imageComp.sprite = achivments.Achivment[itemID].itemIcon;
        animComp.SetTrigger("Anim");
        savedTime = Time.timeScale;
        Time.timeScale = 0.001f;
        StartCoroutine(Wait1());
    }


    private IEnumerator Wait1()
    {
        yield return new WaitForSeconds(0.003f);
        Time.timeScale = savedTime;
        imageComp.color = Color.clear;
    }

}
