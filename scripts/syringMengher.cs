using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class syringMengher : MonoBehaviour
{
    public static List<Sprite> imagesForSyringe = new List<Sprite>();
    [SerializeField] private List<Sprite> imagesss;
    public static List<GameObject> effectsOfSyringes = new List<GameObject>();
    [SerializeField] private List<GameObject> effectsOfSyringessss;
    public static List<bool> IsUsed;
    [SerializeField] private CardOrPills CardsSo;
    void Start()
    {


        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            for (int i = 0; i < 10; i++)
            {
                int randomNumberImage = Random.Range(0, imagesss.Count - 1);
                int randomNumberEffect = Random.Range(0, effectsOfSyringessss.Count - 1);
                imagesForSyringe.Add(imagesss[randomNumberImage]);
                effectsOfSyringes.Add(effectsOfSyringessss[randomNumberEffect]);
                imagesss.Remove(imagesss[randomNumberImage]);
                effectsOfSyringessss.Remove(effectsOfSyringessss[randomNumberEffect]);
            }
        }
    }


}
