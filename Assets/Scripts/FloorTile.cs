using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Deletes tiles that the player has already passed over in order to save memory
 */
public class FloorTile : MonoBehaviour
{
    [Tooltip("Time in seconds to wait until object deletion")]
    [SerializeField] public int secondsBeforeDeletion = 2;
    [Tooltip("The obstacle prefab to spawn in front of the tile")]
    [SerializeField] GameObject obstaclePrefab;
    const int leftObstacleSpawnerIndex = 2;
    const int rightObstacleSpawnerIndex = leftObstacleSpawnerIndex + 3;
    FloorSpawner floorSpawner;

    void Start()
    {
        floorSpawner = GameObject.FindObjectOfType<FloorSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        floorSpawner.SpawnFloor(true);
        Destroy(gameObject, secondsBeforeDeletion);
    }

    /*
     * Randomizes the obstacle spawn in front of the tile between the three different spawner
     * The index's are between 2 to 5 and not 4 due to the Random.Range implementation
     */
    public void SpawnObstacle()
    {
        int spawnedObstacleIndex = Random.Range(leftObstacleSpawnerIndex, rightObstacleSpawnerIndex);
        Transform spawnLocation = transform.GetChild(spawnedObstacleIndex).transform;
        Instantiate(obstaclePrefab, spawnLocation.position, Quaternion.identity, transform);
    }
}
