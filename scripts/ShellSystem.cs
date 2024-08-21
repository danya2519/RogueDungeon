using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShellSystem : MonoBehaviour
{
    public static ShellSystem Instance { get; private set; }

    [SerializeField] private GameObject shieldPrefab;
    private int shields;

    [SerializeField] private Transform gridMenu;

    private List<GameObject> activeShields = new List<GameObject>();

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("there are more than one instance");
        }
        Instance = this;
    }

    private void Start()
    {
        SceneManager.activeSceneChanged += SaveShields;

        AddShields(ES3.Load<int>("shieldsCount", 0));
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            ES3.DeleteKey("shieldsCount");
        }
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.B)) 
        {
            AddShield();
        }
    }

    public void AddShields(int shieldCount)
    {
        for (int i = 0; i < shieldCount; i++)
        {
            AddShield();
        }
    }


    public void AddShield()
    {
        activeShields.Add(Instantiate(shieldPrefab, gridMenu));
        shields++;
    }

    public void RemoveShield()
    {
        Destroy(activeShields[activeShields.Count - 1]);
        activeShields.RemoveAt(activeShields.Count - 1);
        shields--;
    }

    public bool HasShield()
    {
        return activeShields.Count > 0;
    }


    public void SaveShields(Scene arg0, Scene arg1)
    {
        ES3.Save<int>("shieldsCount", shields);
    }
}
