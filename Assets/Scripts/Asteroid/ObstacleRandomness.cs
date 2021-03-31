using UnityEngine;

[RequireComponent(typeof(Obstacle))]
public class ObstacleRandomness : MonoBehaviour
{
    //CONFIG PARAMS
    [Header("Rotation")]
    [SerializeField] float rotationFactor = 5f;
    [SerializeField] float initialRotation = 15f;
    [Header("Scale")]
    [SerializeField] float minSize = 1;
    [SerializeField] float maxSize = 5f;

    //STATE
    float rndmPitch, rndmYaw, rndmRoll;

    //CACHED CLASSES REFERENCES
    Obstacle obstacle;

    //CACHED REFERENCES
    Transform obstacleTransform;


    internal void CustomStart()
    {
        obstacle = GetComponent<Obstacle>();

        SetObstacleModel();
        obstacleTransform = obstacle.obstacleModel.transform;
        SetRandomRotationFactor();
        SetInitialRotation();
        SetInitialSize();
    }

    private void Update()
    {
        Rotate();
    }


    //MODEL
    private void SetObstacleModel()
    {
        Debug.Log(obstacle.obstacleOptions.Length);
        if (obstacle.obstacleOptions.Length == 0) { return; }

        Destroy(obstacle.obstacleModel);
        int randomObstacle = Random.Range(0, obstacle.obstacleOptions.Length);
        obstacle.obstacleModel = Instantiate(obstacle.obstacleOptions[randomObstacle], obstacle.transform);
    }

    //ROTATION
    private void SetRandomRotationFactor()
    {
        rndmPitch = Random.Range(-rotationFactor, rotationFactor);
        rndmYaw = Random.Range(-rotationFactor, rotationFactor);
        rndmRoll = Random.Range(-rotationFactor, rotationFactor);
    }

    private void SetInitialRotation()
    {
        float rndmX = Random.Range(-initialRotation, initialRotation);
        float rndmY = Random.Range(-initialRotation, initialRotation);
        float rndmZ = Random.Range(-initialRotation, initialRotation);

        obstacleTransform.rotation = Quaternion.Euler(rndmX, rndmY, rndmZ);
    }

    private void Rotate()
    {
        obstacleTransform.Rotate(new Vector3(rndmPitch, rndmYaw, rndmRoll), Space.Self);
    }


    //SCALE
    private void SetInitialSize()
    {
        float rndmSize = Random.Range(minSize, maxSize);

        obstacleTransform.localScale = new Vector3(rndmSize, rndmSize, rndmSize);
    }
}