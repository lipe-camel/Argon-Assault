using UnityEngine;

[RequireComponent(typeof(ObstacleRandomness))]
[RequireComponent(typeof(ObstacleCollision))]
public class Obstacle : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] internal GameObject[] obstacleOptions;
    [SerializeField] internal GameObject defaultObstacle;

    //CACHED CLASSES REFERENCES
    ObstacleRandomness obstacleRandomness;
    ObstacleCollision obstacleCollision;

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

        boxCollider = GetComponent<BoxCollider>();
    }

    private void StartCustomStarts()
    {
        obstacleRandomness.CustomStart();
        obstacleCollision.CustomStart();
    }


    internal void DestroyThisObstacle()
    {
        Destroy(gameObject);
    }

}