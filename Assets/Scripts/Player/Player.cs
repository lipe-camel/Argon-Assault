using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    //INSPECTOR REFERENCES
    [SerializeField] internal GameObject playerModel;

    //CACHED REFERENCES
    internal PlayerInput playerInput;
    internal PlayerMovement playerMovement;
    internal Rigidbody rigidBody;

    void Start()
    {
        GetCachedReferences();
        StartCustomStarts();
    }

    private void GetCachedReferences()
    {
        playerInput = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();
        rigidBody = GetComponentInChildren<Rigidbody>();
    }

    private void StartCustomStarts()
    {
        playerInput.CustomStart();
        playerMovement.CustomStart();
    }
}
