using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    [Tooltip("Floor tile prefab to spawn")]
    [SerializeField] GameObject floorPrefab;
    [Tooltip("Number of floors to generate at each iteration")]
    [SerializeField] int floorsToGenerate = 10;
    [Tooltip("Number of first floors to skip obstacle generation")]
    [SerializeField] int firstFloorsToSkip = 3;
    Vector3 nextSpawnPoint;
    const int firstFloorLocationToSpawn = 0;

    public void SpawnFloor(bool initiateSpawn)
    {
        GameObject tmp = Instantiate(floorPrefab, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = tmp.transform.GetChild(1).transform.position;
        if (initiateSpawn)
        {
            tmp.GetComponent<FloorTile>().SpawnObstacle();
        }
    }

    private void Start()
    {
        for (int i = firstFloorLocationToSpawn; i < floorsToGenerate; i++)
        {
            if(i < firstFloorsToSkip)
            {
                SpawnFloor(false);
            }
            else
            {
                SpawnFloor(true);
            }
        }
    }
}
