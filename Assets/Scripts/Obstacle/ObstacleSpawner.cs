using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] GameObject obstacle;
    [SerializeField] float xSpawnLimit = 19f, ySpawnLimit = 12f;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] float gameSpeed = 2f;

    //STATES
    bool spawn = true;
    int obstacleCount;


    private IEnumerator Start()
    {   

        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        //INSTANTIATE OBSTACLE IN PARENT GAMEOBJECT
        float rndmX = Random.Range(-xSpawnLimit, xSpawnLimit);
        float rndmY = Random.Range(-ySpawnLimit, ySpawnLimit);
        Vector3 randomPos = new Vector3(rndmX, rndmY, transform.position.z);

        GameObject spawnedObstacle = Instantiate(obstacle, randomPos, transform.rotation);
        spawnedObstacle.transform.parent = transform;


        //RENAME OBSTACLE
        spawnedObstacle.gameObject.name = $"Obstacle ({obstacleCount})";
        obstacleCount++;


        //APPLY ZED MOVEMENT
        Rigidbody obstacleRigidbody = spawnedObstacle.GetComponent<Rigidbody>();
        obstacleRigidbody.velocity = new Vector3(0, 0, -gameSpeed);
    }
}