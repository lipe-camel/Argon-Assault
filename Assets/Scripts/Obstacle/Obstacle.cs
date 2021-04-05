using UnityEngine;

[RequireComponent(typeof(ObstacleRandomness))]
[RequireComponent(typeof(ObstacleMovement))]
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
    internal ObstacleMovement obstacleMovement;
    internal ObstacleCollision obstacleCollision;
    internal ObstacleHealth obstacleHealth;
    internal ObstacleFX obstacleFX;
    internal ObstacleScore obstacleScore;

    //CACHED COMPONENT REFERENCES
    internal GameObject obstacleModel;
    internal Rigidbody rigidBody;

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
        obstacleMovement = GetComponent<ObstacleMovement>();
        obstacleCollision = GetComponent<ObstacleCollision>();
        obstacleHealth = GetComponent<ObstacleHealth>();
        obstacleFX = GetComponent<ObstacleFX>();
        obstacleScore = GetComponent<ObstacleScore>();

        rigidBody = GetComponent<Rigidbody>();

        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void StartCustomStarts()
    {
        obstacleRandomness.CustomStart();
        obstacleMovement.CustomStart();
        obstacleCollision.CustomStart();
        obstacleHealth.CustomStart();
        obstacleFX.CustomStart();
        obstacleScore.CustomStart();
    }
}