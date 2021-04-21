using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] GameObject obstacle;
    [SerializeField] float xSpawnLimit = 19f, ySpawnLimit = 12f;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;

    //STATES
    //public bool spawn;
    int obstacleCount;

    private void Start()
    {
        StartCoroutine(Spawn(true));
    }

    public IEnumerator Spawn(bool spawn)
    {   

        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        //GET THE RANDOM VECTOR3
        float rndmX = Random.Range(-xSpawnLimit, xSpawnLimit);
        float rndmY = Random.Range(-ySpawnLimit, ySpawnLimit);
        Vector3 randomPos = new Vector3(rndmX, rndmY, transform.position.z);

        //INSTANTIATE OBSTACLE IN PARENT GAMEOBJECT
        GameObject spawnedObstacle = Instantiate(obstacle, randomPos, transform.rotation);
        spawnedObstacle.transform.parent = transform;


        //RENAME OBSTACLE
        spawnedObstacle.gameObject.name = $"Obstacle ({obstacleCount})";
        obstacleCount++;
    }
}