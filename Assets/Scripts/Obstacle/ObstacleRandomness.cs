using UnityEngine;

[RequireComponent(typeof(Obstacle))]
public class ObstacleRandomness : MonoBehaviour
{
    //CONFIG PARAMS
    [Header("Rotation")]
    [SerializeField] [Tooltip("How much the object will rotate per second")]
    float rotationFactor = 5f;
    [SerializeField] [Tooltip("How much the object can be rotated at the start")] 
    float initialRotation = 15f;

    [Header("Scale")]
    [SerializeField] float minSize = 1;
    [SerializeField] float maxSize = 5f;

    //STATS
    float rndmPitch, rndmYaw, rndmRoll;
    internal float rndmSize;

    //CACHED CLASSES REFERENCES
    Obstacle obstacle;

    //CACHED REFERENCES
    Transform obstacleTransform;


    internal void CustomStart()
    {
        obstacle = GetComponent<Obstacle>();

        SetObstacleModel();
        SetRandomRotationFactor();
        SetInitialRotation(initialRotation);
        SetModelSize(obstacle.obstacleModel, minSize, maxSize);
    }

    private void Update()
    {
        Rotate();
    }


    //MODEL
    private void SetObstacleModel()
    {
        if (obstacle.obstacleOptions.Length > 0)
        {
            var randomObstacle = obstacle.obstacleOptions[Random.Range(0, obstacle.obstacleOptions.Length)];
            InstantiateModel(randomObstacle);
        }
        else
        {
            InstantiateModel(obstacle.defaultObstacle);
        }
    }

    private void InstantiateModel(GameObject obstacleModel)
    {
        obstacle.obstacleModel = Instantiate(obstacleModel, obstacle.transform); ;
        obstacle.obstacleModel.transform.parent = transform;
    }


    //POSITION
    internal Vector3 GetRandomPos(float posFlutuation)
    {
        return new Vector3(
                Random.Range(transform.position.x - posFlutuation, transform.position.x + posFlutuation),
                Random.Range(transform.position.y - posFlutuation, transform.position.y + posFlutuation),
                Random.Range(transform.position.z - posFlutuation, transform.position.z + posFlutuation));
    }


    //ROTATION
    //this sets the rotation to be used when summoned
    

    private void SetInitialRotation(float initialRoatation)
    {
        obstacle.obstacleModel.transform.rotation = Quaternion.Euler(GetRandomizedV3(initialRotation));
    }

    //this sets the rotation to be used in the rotation update
    private void SetRandomRotationFactor()
    {
        rndmPitch = Random.Range(-rotationFactor, rotationFactor);
        rndmYaw = Random.Range(-rotationFactor, rotationFactor);
        rndmRoll = Random.Range(-rotationFactor, rotationFactor);
    }

    private void Rotate()
    {
        obstacle.obstacleModel.transform.Rotate(
            new Vector3(rndmPitch, rndmYaw, rndmRoll), Space.Self);
    }


    //SCALE
    internal void SetModelSize(GameObject model, float minSize, float maxSize)
    {
        rndmSize = Random.Range(minSize, maxSize);
        Vector3 rndmV3Size = new Vector3(rndmSize, rndmSize, rndmSize);

        model.transform.localScale = rndmV3Size;
    }


    //VECTOR3

    internal Vector3 GetRandomizedV3(float flutuationValue)
    {
        float rndmX = Random.Range(-flutuationValue, flutuationValue);
        float rndmY = Random.Range(-flutuationValue, flutuationValue);
        float rndmZ = Random.Range(-flutuationValue, flutuationValue);
        return new Vector3(rndmX, rndmY, rndmZ);
    }
}