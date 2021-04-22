using UnityEngine;

[RequireComponent(typeof(ObstacleRandomness))]
[RequireComponent(typeof(ObstacleMovement))]
[RequireComponent(typeof(ObstacleCollision))]
[RequireComponent(typeof(ObstacleHealth))]
[RequireComponent(typeof(ObstacleDamage))]
[RequireComponent(typeof(ObstacleParticles))]
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
    internal ObstacleDamage obstacleDamage;
    internal ObstacleSFX obstacleSFX;
    internal ObstacleParticles obstacleParticles;
    internal ObstacleExplosion obstacleExplosion;
    internal ObstacleScore obstacleScore;

    //CACHED COMPONENT REFERENCES
    internal GameObject obstacleModel;
    internal Rigidbody rigidBody;
    internal BoxCollider boxCollider;
    internal MeshRenderer meshRenderer;

    //CACHED EXRTERNAL REFERENCES
    internal ScoreBoard scoreBoard;
    internal GameState gameState;

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
        obstacleDamage = GetComponent<ObstacleDamage>();
        obstacleSFX = GetComponent<ObstacleSFX>();
        obstacleParticles = GetComponent<ObstacleParticles>();
        obstacleExplosion = GetComponent<ObstacleExplosion>();
        obstacleScore = GetComponent<ObstacleScore>();

        rigidBody = GetComponent<Rigidbody>();

        scoreBoard = FindObjectOfType<ScoreBoard>();
        gameState = FindObjectOfType<GameState>();
    }

    internal void GetModelComponentReferences()
    {
        boxCollider = obstacleModel.GetComponentInChildren<BoxCollider>();
        meshRenderer = obstacleModel.GetComponentInChildren<MeshRenderer>();
    }

    private void StartCustomStarts()
    {
        obstacleRandomness.CustomStart();
        obstacleMovement.CustomStart();
        obstacleCollision.CustomStart();
        obstacleHealth.CustomStart();
        obstacleDamage.CustomStart();
        obstacleSFX.CustomStart();
        obstacleParticles.CustomStart();
        obstacleExplosion.CustomStart();
        obstacleScore.CustomStart();
    }
}