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

    private void Start()
    {
        obstacleRandomness = GetComponent<ObstacleRandomness>();
        obstacleCollision = GetComponent<ObstacleCollision>();

        obstacleRandomness.CustomStart();
        obstacleCollision.CustomStart();
    }

    internal void DestroyThisObstacle()
    {
        Destroy(gameObject);
    }

}