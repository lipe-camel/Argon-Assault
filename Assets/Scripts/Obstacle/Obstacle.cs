using UnityEngine;

[RequireComponent(typeof(ObstacleRandomness))]
[RequireComponent(typeof(ObstacleCollision))]
public class Obstacle : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] internal GameObject[] obstacleOptions;
    [SerializeField] internal GameObject defaultObstacle;

    //CACHED CLASSES REFERENCES
    internal ObstacleRandomness obstacleRandomness;
    internal ObstacleCollision obstacleCollision;
    internal ObstacleHealth obstacleHealth;
    internal ObstacleFX obstacleFX;

    //CACHED COMPONENT REFERENCES
    internal GameObject obstacleModel;
    internal BoxCollider boxCollider;


    private void Start()
    {
        GetCachedReferences();
        StartCustomStarts();
    }

    private void GetCachedReferences()
    {
        obstacleRandomness = GetComponent<ObstacleRandomness>();
        obstacleCollision = GetComponent<ObstacleCollision>();
        obstacleHealth = GetComponent<ObstacleHealth>();
        obstacleFX = GetComponent<ObstacleFX>();

        boxCollider = GetComponent<BoxCollider>();
    }

    private void StartCustomStarts()
    {
        obstacleRandomness.CustomStart();
        obstacleCollision.CustomStart();
        obstacleHealth.CustomStart();
        obstacleFX.CustomStart();
    }
}