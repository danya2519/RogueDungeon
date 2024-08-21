using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CKBMeneger : MonoBehaviour
{
    [Range(0,99)] public static int coins;
    [Range(0, 99)] public static int keys;
    [Range(0, 99)] public static int bombs;

    private void Update()
    {
        coins = Mathf.Clamp(coins,0 , 99);
        keys = Mathf.Clamp(keys, 0 , 99);
        bombs = Mathf.Clamp(bombs, 0 , 99);
    }
}
