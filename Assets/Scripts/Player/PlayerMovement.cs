using System;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    //CONFIG STATS
    [Header("Screen Movement")]
    [SerializeField] float xValue;
    [SerializeField] float yValue;
    [Header("Movement")]
    [SerializeField] float movementSpeed = 85f;

    [Header("Screen Rotation Correction")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 1.5f;
    [Header("Rotation")]
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float controlRollFactor = -10f;

    // CACHED REFERENCES
    Player player;
    Transform playerTransform;

    public void CustomStart()
    {
        player = GetComponent<Player>();
        playerTransform = player.playerModel.transform;
    }

    public void ProcessPlayerMovement(float xThrow, float yThrow)
    {
        Move(xThrow, yThrow);
        ProcessRotation(xThrow, yThrow);
    }
    private void Move(float xThrow, float yThrow)
    {
        float deltaX = xThrow * Time.deltaTime * movementSpeed;
        float deltaY = yThrow * Time.deltaTime * movementSpeed;

        float newXPos = Mathf.Clamp(playerTransform.localPosition.x + deltaX, -xValue, xValue);
        float newYPos = Mathf.Clamp(playerTransform.localPosition.y + deltaY, -yValue, yValue);

        playerTransform.localPosition = new Vector3(newXPos, newYPos);
    }

    private void ProcessRotation(float xThrow, float yThrow)
    {
        float pitch = playerTransform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw =   playerTransform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        playerTransform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
