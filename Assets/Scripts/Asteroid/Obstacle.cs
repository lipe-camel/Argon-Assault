using UnityEngine;

[RequireComponent(typeof(ObstacleRandomness))]
public class Obstacle : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] internal GameObject[] obstacleOptions;

    //CACHED CLASSES REFERENCES
    ObstacleRandomness obstacleRandomness;

    //CACHED COMPONENT REFERENCES
    internal GameObject obstacleModel;

    void Start()
    {
        obstacleRandomness = GetComponent<ObstacleRandomness>();
        obstacleModel = GetComponentInChildren<MeshRenderer>().gameObject;
        obstacleRandomness.CustomStart();
    }
}