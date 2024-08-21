using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAllAchivments : MonoBehaviour
{
    [SerializeField] private Achivments achivments;
    void Start()
    {
        for (int i = 0; i < achivments.Achivment.Count; i++)
        {
            ES3.Save<bool>(achivments.Achivment[i].name, false);
            ES3.Save<int>(achivments.Achivment[i].name + "KillCount", 0);
        }
    }
}
