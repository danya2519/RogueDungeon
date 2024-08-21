using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AchivmentsData", menuName = "achivmentMenu/achivmentsMenu")]
public class Achivments : ScriptableObject
{
    public List<Achivment> Achivment;
}

[System.Serializable]
public class Achivment
{
    public string name;
    public bool isUnlocked;
    public int Id;

    public Sprite itemIcon;
}
