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
    bool spawn = true;


    private IEnumerator Start()
    {   

        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnObstacle();
            //apply -z velocity
        }
    }

    private void SpawnObstacle()
    {
        float rndmX = Random.Range(-xSpawnLimit, xSpawnLimit);
        float rndmY = Random.Range(-ySpawnLimit, ySpawnLimit);
        Vector3 randomPos = new Vector3(rndmX, rndmY, transform.position.z);

        GameObject spawnedObstacle = Instantiate(obstacle, randomPos, transform.rotation);
        spawnedObstacle.transform.parent = transform;
    }
}