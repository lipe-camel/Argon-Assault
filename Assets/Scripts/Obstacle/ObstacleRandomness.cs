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
    Vector3 randomRotationFactor;

    //CACHED CLASSES REFERENCES
    Obstacle obstacle;


    internal void CustomStart()
    {
        obstacle = GetComponent<Obstacle>();

        SetObstacleModel();
        SetRandomRotationFactor();
        SetInitialRotation(initialRotation);
        SetRandomizedScale(obstacle.obstacleModel, minSize, maxSize);
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
    internal Vector3 GetRandomRotation(float flutuationValue)
    {
        float rndmX = Random.Range(-flutuationValue, flutuationValue);
        float rndmY = Random.Range(-flutuationValue, flutuationValue);
        float rndmZ = Random.Range(-flutuationValue, flutuationValue);
        return new Vector3(rndmX, rndmY, rndmZ);
    }

    private void SetInitialRotation(float initialRoatation)
    {
        obstacle.obstacleModel.transform.rotation = Quaternion.Euler(GetRandomRotation(initialRotation));
    }

    //this sets the rotation to be used in Rotate()
    private void SetRandomRotationFactor()
    {
        float rndmPitch = Random.Range(-rotationFactor, rotationFactor);
        float rndmYaw = Random.Range(-rotationFactor, rotationFactor);
        float rndmRoll = Random.Range(-rotationFactor, rotationFactor);
        randomRotationFactor = new Vector3(rndmPitch, rndmYaw, rndmRoll);
    }

    private void Rotate()
    {
        obstacle.obstacleModel.transform.Rotate(randomRotationFactor, Space.Self);
    }


    //SCALE
    internal float GetRandomScale(float minSize, float maxSize)
    {
        return Random.Range(minSize, maxSize);
    }

    internal void SetRandomizedScale(GameObject model, float minSize, float maxSize)
    {
        float rndmScale = GetRandomScale(minSize, maxSize);
        model.transform.localScale = new Vector3(rndmScale, rndmScale, rndmScale);
    }


    //VELOCITY
    internal Vector3 GetRandomVelocity(float flutuationValue, float minValue)
    {
        float rndmX = Random.Range(-flutuationValue, flutuationValue);
        float rndmY = Random.Range(-flutuationValue, flutuationValue);
        float rndmZ = Random.Range(-flutuationValue, flutuationValue);
        rndmX = CheckForMin(rndmX, minValue);
        rndmY = CheckForMin(rndmY, minValue);
        rndmZ = CheckForMin(rndmZ, minValue);
        return new Vector3(rndmX, rndmY, rndmZ);
    }

    private static float CheckForMin(float checkValue, float minValue)
    {
        if (checkValue > 0 && checkValue <= minValue)
        {
            return minValue;
        }
        else if (checkValue <= 0 && checkValue >= -minValue)
        {
            return -minValue;
        }
        else
        {
            return checkValue;
        }
    }
}