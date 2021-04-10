using UnityEngine;

[RequireComponent(typeof(Obstacle))]
internal class ObstacleMovement : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] internal float gameSpeed = 60f;
    [SerializeField] internal float minSpeed = 6f;
    [SerializeField][Tooltip("The speed decreased per hit")]
                     internal float speedDecreased = 0.5f;

    //STATES
    float currentSpeed;

    //CACHED CLASSES REFERENCES
    Obstacle obstacle;

    internal void CustomStart()
    {
        obstacle = GetComponent<Obstacle>();

        SetMovementSpeed(gameSpeed);
    }

    internal void DecreaseSpeed()
    {
        float newSpeed = Mathf.Clamp(currentSpeed -= speedDecreased, minSpeed, gameSpeed);
        SetMovementSpeed(newSpeed);
    }

    private void SetMovementSpeed(float movementSpeed)
    {
        obstacle.rigidBody.velocity = new Vector3(0, 0, -movementSpeed);
        currentSpeed = movementSpeed;
    }
}