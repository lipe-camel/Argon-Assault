using UnityEngine;

[RequireComponent(typeof(ObstacleRandomness))]
[RequireComponent(typeof(ObstacleCollision))]
[RequireComponent(typeof(ObstacleHealth))]
[RequireComponent(typeof(ObstacleFX))]
[RequireComponent(typeof(ObstacleScore))]
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
    internal ObstacleScore obstacleScore;

    //CACHED COMPONENT REFERENCES
    internal GameObject obstacleModel;
    internal BoxCollider boxCollider;

    //CACHED EXRTERNAL REFERENCES
    internal ScoreBoard scoreBoard;

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
        obstacleScore = GetComponent<ObstacleScore>();

        boxCollider = GetComponent<BoxCollider>();

        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void StartCustomStarts()
    {
        obstacleRandomness.CustomStart();
        obstacleCollision.CustomStart();
        obstacleHealth.CustomStart();
        obstacleFX.CustomStart();
        obstacleScore.CustomStart();
    }
}