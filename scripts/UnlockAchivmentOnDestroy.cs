using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockAchivmentOnDestroy : MonoBehaviour
{
    [SerializeField] private Achivments achivments;
    [SerializeField] private int Id;
    [SerializeField] private int killCount;


    private void OnDestroy()
    {
        if (killCount == 0 && !ES3.Load<bool>(achivments.Achivment[Id].name, false) || !ES3.Load<bool>(achivments.Achivment[Id].name, false) && ES3.Load<int>(achivments.Achivment[Id].name + "KillCount", 0) >= killCount - 1)
        {
            ES3.Save<bool>(achivments.Achivment[Id].name, true);
            GameObject.FindGameObjectWithTag("AnimUnlock").GetComponent<ItemUnlockAnim>().UnlockAnim(Id);
        }
        else
        {
            ES3.Save<int>(achivments.Achivment[Id].name + "KillCount", ES3.Load<int>(achivments.Achivment[Id].name + "KillCount", 0) + 1);
            //print(killCount - ES3.Load<int>(achivments.Achivment[Id].name + "KillCount", 0));
        }
    }
}
