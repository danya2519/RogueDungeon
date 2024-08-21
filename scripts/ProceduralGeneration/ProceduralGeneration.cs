using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProceduralGeneration : MonoBehaviour
{
    public static ProceduralGeneration Instance { get; private set; }

    public static int sceneLoops;

    [SerializeField] private Transform lobby;

    public GameObject testObject;//TODO

    [SerializeField] private RoomsData roomsData;
    [SerializeField] private BossDataSO bossData;
    [SerializeField] private GameObject treasureRoom;
    [SerializeField] private SpecialRoomsProbabylitiesSO specialRooms;

    [SerializeField, Range(5,20)] private int minRoomCount;
    [SerializeField, Range(7,40)] private int maxRoomCount;
    
    public int currentLevelRoomCount;
    private List<Origin> levelOriginList = new List<Origin>();
    public List<Transform> levelRoomList = new List<Transform>();

    private float timer = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentLevelRoomCount = Random.Range(minRoomCount, maxRoomCount);
        AddLevelOrigins(lobby);

        GenerateLevel();
    }

    private void AddLevelOrigins(Transform room)
    {
        //List<Origin> originList = new List<Origin>();
        foreach (Transform item in room)
        {
            if (item.TryGetComponent(out Origin newOrigin))
            {
                levelOriginList.Add(newOrigin);
            }
        }
        
    }

    private void Update()
    {

        
        timer += Time.deltaTime;

        /*if (timer >= 1)
        {
            SpawnRoom();
            timer = 0;
        }
*/

    }

    private bool TrySpawnRoom(GameObject roomToSpawn)
    {
        

        int originIndex = Random.Range(0, levelOriginList.Count);

        //GameObject roomToSpawn = roomsData.rooms[1];
        GameObject spawnedRoom = null;
        try
        {
            if(sceneLoops < 11)
            spawnedRoom = Instantiate(roomToSpawn, levelOriginList[originIndex].transform.position,
                                levelOriginList[originIndex].transform.rotation);
        }
        catch
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            sceneLoops++;
        }
       
        
        
        Origin newOrigin = levelOriginList[originIndex];
        levelOriginList.Remove(newOrigin);
        Destroy(newOrigin.gameObject);

        if (spawnedRoom.GetComponent<Room>().IsOverlapingOtherRoom())
        {
            Destroy(spawnedRoom);
            return false;
        }
        levelRoomList.Add(spawnedRoom.transform);
        AddLevelOrigins(spawnedRoom.transform);
        return true;
    }

    private void GenerateLevel()
    {
        for (int i = 0; i < currentLevelRoomCount; i++)
        {
            while (true)
            {
                try
                {
                    if (sceneLoops < 11)
                        if (TrySpawnRoom(roomsData.rooms[Random.Range(0, roomsData.rooms.Count)])) break;
                }
                catch
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    sceneLoops++;
                }
            }
            
            //HandleRoomSpawn(i);
        }
        SpawnTreasureRoom();
        if(testObject != null)
        {
            while (true)
            {
                if (TrySpawnRoom(testObject)) break;
            }
        }
        SpawnBossRoom();
        for (int i = 0; i < specialRooms.SpecialRoomsList.Count; i++)
        {
            SpawnSpecialRoom(i);
        }
    }
    private void SpawnBossRoom()
    {
        
        while (true)
        {
           
            Origin farestOrigin = levelOriginList[0];

            foreach (var point in levelOriginList)
            {
                float lastDistance = Vector3.Distance(farestOrigin.transform.position, lobby.transform.position);
                float currentDistance = Vector3.Distance(point.transform.position, lobby.transform.position);
                if (currentDistance > lastDistance)
                {
                    farestOrigin = point;
                }
            }
            if (TrySpawnRoom(bossData.bossDataList[Random.Range(0, bossData.bossDataList.Count)].roomPrefab)) break;
            levelOriginList.Remove(farestOrigin);

        }
    }

    private void SpawnTreasureRoom()
    {
        if(treasureRoom != null)
        {
            while (true)
            {
                Origin closestOrigin = null;
                try
                {
                    closestOrigin = levelOriginList[0];
                }
                catch
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }

                foreach (var point in levelOriginList)
                {
                    float lastDistance = Vector3.Distance(closestOrigin.transform.position, lobby.transform.position);
                    float currentDistance = Vector3.Distance(point.transform.position, lobby.transform.position);

                    if (currentDistance < lastDistance)
                    {
                        closestOrigin = point;
                    }
                }

                if (TrySpawnRoom(treasureRoom)) break;
                levelOriginList.Remove(closestOrigin);

            }
        }

    }

    private void SpawnSpecialRoom(int roomID)
    {
        if (Random.Range(0,100) < specialRooms.SpecialRoomsList[roomID].probabylity && specialRooms != null)
        {
            while (true)
            {
                if (TrySpawnRoom(specialRooms.SpecialRoomsList[roomID].prefab)) break;
            }
        }
    }

    public void HandleRoomSpawn(int index)
    {
        //Room newRoom = SpawnRoom();
        //newRoom.index = index;
    }

    public void RemoveOriginFromList(Origin origin)
    {
        levelOriginList.Remove(origin);
    }

    public void UpdateOriginList()
    {
        levelOriginList.Clear();
        foreach (var item in levelRoomList)
        {
            AddLevelOrigins(item);
        }
    }
}
