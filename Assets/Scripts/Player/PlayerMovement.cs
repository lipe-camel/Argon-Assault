using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    //CONFIG STATS
    [Header("Screen Movement")]
    [SerializeField] [Tooltip("The horizontal limit value that the player is allowed to move")]
    float xValue;
    [SerializeField] [Tooltip("The vertical limit value that the player is allowed to move")]
    float yValue;
    [SerializeField] Vector3 menuPos = new Vector3(0, -18, 0);

    [Header("Movement")]
    [SerializeField] [Tooltip("The speed of the player")]
    float movementSpeed = 85f;

    [Header("Screen Rotation Correction")]
    [SerializeField] [Tooltip("How much the player will rotate in the x axis to pass the illusion of perspective")]
    float positionPitchFactor = -2f;
    [SerializeField] [Tooltip("How much the player will rotate in the y axis to pass the illusion of perspective")]
    float positionYawFactor = 1.5f;

    [Header("Rotation")]
    [SerializeField] [Tooltip("How much the player will rotate in the x axis to have a more dynamic movement")]
    float controlPitchFactor = -10f;
    [SerializeField] [Tooltip("How much the player will rotate in the z axis to have a more dynamic movement")] 
    float controlRollFactor = -10f;

    // CACHED REFERENCES
    Player player;

    internal void CustomStart()
    {
        player = GetComponent<Player>();
    }

    internal void ProcessPlayerMovement(float xThrow, float yThrow)
    {
        Move(xThrow, yThrow);
        ProcessRotation(xThrow, yThrow);
    }
    private void Move(float xThrow, float yThrow)
    {
        float deltaX = xThrow * Time.deltaTime * movementSpeed;
        float deltaY = yThrow * Time.deltaTime * movementSpeed;

        float newXPos = Mathf.Clamp(player.transform.localPosition.x + deltaX, -xValue, xValue);
        float newYPos = Mathf.Clamp(player.transform.localPosition.y + deltaY, -yValue, yValue);

        player.transform.localPosition = new Vector3(newXPos, newYPos);  
    }

    private void ProcessRotation(float xThrow, float yThrow)
    {
        float pitch = player.transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw =   player.transform.localPosition.x * positionYawFactor;
        float roll =  xThrow * controlRollFactor;

        player.transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    internal void CanMove(bool boolean)
    {
        player.canMove = boolean;
    }

    internal void ResetPosition()
    {
        player.transform.localPosition = new Vector3(0, 0, 0);
    }

    internal void SetMenuPosition()
    {
        player.transform.localPosition = menuPos;
    }
}
