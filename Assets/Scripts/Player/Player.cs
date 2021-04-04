using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerFire))]
[RequireComponent(typeof(PlayerCollision))]
[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerFX))]
public class Player : MonoBehaviour
{
    //INSPECTOR REFERENCES
    [SerializeField] internal ParticleSystem[] lasers;

    //STATES
    internal bool isAlive = true;

    //CACHED CLASSES REFERENCES
    internal PlayerInput playerInput;
    internal PlayerMovement playerMovement;
    internal PlayerFire playerFire;
    internal PlayerCollision playerColision;
    internal PlayerHealth playerHealth;
    internal PlayerFX playerFX;

    //CACHED COMPONENT REFERENCES
    internal Rigidbody rigidBody;
    internal BoxCollider boxCollider;

    //CACHED EXTERNAL REFERENCES
    internal SceneLoader sceneLoader;

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
        playerColision = GetComponent<PlayerCollision>();
        playerHealth = GetComponent<PlayerHealth>();
        playerFX = GetComponent<PlayerFX>();

        rigidBody = GetComponentInChildren<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();

        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    private void StartCustomStarts()
    {
        playerInput.CustomStart();
        playerMovement.CustomStart();
        playerFire.CustomStart();
        playerColision.CustomStart();
        playerHealth.CustomStart();
        playerFX.CustomStart();
    }
}