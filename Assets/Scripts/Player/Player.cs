using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerFire))]
public class Player : MonoBehaviour
{
    //INSPECTOR REFERENCES
    [SerializeField] internal GameObject playerModel;
    [SerializeField] internal ParticleSystem[] lasers;

    //CACHED CLASSES REFERENCES
    internal PlayerInput playerInput;
    internal PlayerMovement playerMovement;
    internal PlayerFire playerFire;

    //CACHED COMPONENT REFERENCES
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
        playerFire = GetComponent<PlayerFire>();
        rigidBody = GetComponentInChildren<Rigidbody>();
    }

    private void StartCustomStarts()
    {
        playerInput.CustomStart();
        playerMovement.CustomStart();
        playerFire.CustomStart();
    }
}