using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private PickUpsData PickUpsData;
    private EnemySpawner enemySpawner;

    private void Start()
    {
        FindEnemySpawner();
        if(enemySpawner == null)
        {
            //print(gameObject.name);
        }
    }



    private void Update()
    {
        if(enemySpawner != null)
        {
            //print(enemySpawner.GetActivatedState() == true && !enemySpawner.AllEnemiesIsDefeted());
            if (enemySpawner.GetActivatedState() == true && !enemySpawner.AllEnemiesIsDefeted())
            {
                SetDoorsLockState(true);
            }
            else
            {
                SetDoorsLockState(false);
            }
        }
    }

    public bool IsOverlapingOtherRoom()
    {

        BoxCollider boxCollider = GetComponent<BoxCollider>();
        List<Room> overlapedRooms = new();
        Collider[] overlapedObjects = Physics.OverlapBox(transform.TransformPoint(boxCollider.center), boxCollider.size / 2, transform.rotation);
        foreach (Collider item in overlapedObjects)
        {
            if(item.TryGetComponent(out Room room))
            {
                overlapedRooms.Add(room);
            }
        }
        
        if (overlapedRooms.Count > 1)
        {
            return true;
        }
        return false;

    }

    private void FindEnemySpawner()
    {
        foreach (Transform item in transform)
        {
            if (item.TryGetComponent(out EnemySpawner enemySpawner))
            {
                this.enemySpawner = enemySpawner;
                return;
            }
        }
    }

    private void SetDoorsLockState(bool lockState)
    {
        foreach (Transform item in transform)
        {
            Door currentDoor = item.GetComponentInChildren<Door>();
                if (currentDoor != null)
                {

                    currentDoor.SetLockState(lockState);
                    //print(currentDoor.name);
                }
            
        }
/*        if(lockState == false)
        {
            Transform spawnPoint = transform;
            spawnPoint.position = GetComponent<BoxCollider>().center + new Vector3(0,2,0);
            Instantiate(PickUpsData.PickUpsTypeList[UnityEngine.Random.Range(0, PickUpsData.PickUpsTypeList.Count)], spawnPoint.position, Quaternion.identity);
        }*/
    }



    /*    public int index;

        private void OnCollisionEnter(Collision collision)
        {
            print("f");
            if (collision.transform.TryGetComponent(out Room room))
            {
                if (index > room.index)
                {
                    ProceduralGeneration.Instance.levelRoomList.Remove(transform);
                    Destroy(gameObject);
                    //ProceduralGeneration.Instance.currentLevelRoomCount++;
                    ProceduralGeneration.Instance.UpdateOriginList();
                    ProceduralGeneration.Instance.UpdateOriginList();
                }
                else
                {
                    ProceduralGeneration.Instance.levelRoomList.Remove(room.transform);
                    Destroy(room.gameObject);
                    //ProceduralGeneration.Instance.currentLevelRoomCount++;
                    ProceduralGeneration.Instance.UpdateOriginList();
                }

                //ProceduralGeneration.Instance.HandleRoomSpawn(ProceduralGeneration.Instance.currentLevelRoomCount + 1);


            }
        }*/
}
