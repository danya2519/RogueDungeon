using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HealthBar : MonoBehaviour
{
    
    public static HealthBar Instance {get; private set;}

    public delegate void OnTakeDamage();

    public OnTakeDamage onPlayerTakeDamage;

    public List<GameObject> heartList = new List<GameObject>();
    public List<GameObject> heartContainerList = new List<GameObject>();
    public List<int> heartIdexes = new List<int>();

    private HealthComponent healthComponent;

    [SerializeField] private GameObject hearts; 
    [SerializeField] private GameObject heart; 
    [SerializeField] private GameObject conteiner; 
    [SerializeField] private GameObject conteiners;
    [SerializeField] private HeartsData heartsData;



    private void Awake()
    {
        Instance = this;
        //heartList.Add()
        healthComponent = GetComponent<HealthComponent>();
    }


    private void Start()
    {
        SceneManager.activeSceneChanged += SaveHearts;
        /*        if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    
                }*/
        /*        if (!ES3.KeyExists("HeartIndexList"))*/
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            ES3.DeleteKey("HeartIndexList");
            ES3.DeleteKey("HeartContainers");
            GiveStartHealth(4);
        }
        else
        {
            LoadHearts();
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            RemoveHeart();
        }


    }   

   
    public void AddConteiner()
    {
        heartContainerList.Add(AddObjectToParent(conteiner, conteiners.transform));
    }

    public bool TryRemoveConteiner()
    {
        if (heartContainerList.Count > 0)
        {
            heartContainerList.Remove(heartContainerList[heartContainerList.Count - 1]);
            return true;
        }
        return false;
       
    }


    public void AddHeart(int index)
    {
        heartIdexes.Add(index);
        GameObject heartPrefab = heartsData.heartTypeList[index];
        healthComponent.ChangeHealth(1);
        heartList.Add(AddObjectToParent(heartPrefab, hearts.transform));
    }

    public void RemoveHeart()
    {
        onPlayerTakeDamage?.Invoke();
        if (ShellSystem.Instance.HasShield())
        {
            ShellSystem.Instance.RemoveShield();
        }
        else
        {
            healthComponent.ChangeHealth(-1);
            Destroy(heartList[heartList.Count - 1]);
            heartList.Remove(heartList[heartList.Count - 1]);
            heartIdexes.RemoveAt(heartIdexes.Count - 1);
        }
        
    }


    void LoadHearts()
    {
        StartCoroutine(Wait());
    }

    void SaveHearts(Scene arg0, Scene arg1)
    {
        ES3.Save<List<int>>("HeartIndexList", heartIdexes);
        ES3.Save<int>("HeartContainers", heartContainerList.Count);
    }


    private void GiveStartHealth(int heatrsCount)
    {
        for (int i = 0; i < heatrsCount; i++)
        {
            AddConteiner();
            AddHeart(0);
        }
    }

    private void GiveContainers(int heatrsCount)
    {
        for (int i = 0; i < heatrsCount; i++)
        {
            AddConteiner();
        }
    }

    private void GiveHealth(int heatrsCount)
    {
        for (int i = 0; i < heatrsCount; i++)
        {
            AddHeart(0);
        }
    }


    private void ClearHealthBar()
    {
        ClearChildObjects(hearts.transform);
    }

    public int GetHealth()
    {
        return healthComponent.GetHealth();
    }

/*    public void SaveTypes(Scene arg0, Scene arg1)
    {
        List<GameObject> types = ES3.Load<List<GameObject>>("PlayerHealth");
        for (int i = 0; i < heartList.Count; i++)
        {
            types.Add(heartList[i]);
            ES3.Save<List<GameObject>>("PlayerHealth", types);
        }
        ES3.Save<int>("ContainerCount", heartContainerList.Count);
    }*/



    public void UpdateHealthBar()
    {
        ClearHealthBar();
       
    }

    

    private GameObject AddObjectToParent(GameObject heartPrefab, Transform parent)
    { 
          return Instantiate(heartPrefab, parent);

    }


    private void ClearChildObjects(Transform parent)
    {
        foreach (Transform item in parent)
        {
            Destroy(item.gameObject);
        }
    }

    private IEnumerator Wait()
    {

        yield return new WaitForSeconds(0.2f);
        List<int> loadedHeartIdexes = ES3.Load<List<int>>("HeartIndexList");
       
       

        for (int i = 0; i < ES3.Load<int>("HeartContainers"); i++)
        {
            AddConteiner();
        }
        foreach (int index in loadedHeartIdexes)
        {
            AddHeart(index);
        }
    }

}



public enum HeartType
{
    Simple,
    Cursed,
    Tropic,
    Lava,
    Polluted,
    Angel,
    Devil,
    Magic
}

