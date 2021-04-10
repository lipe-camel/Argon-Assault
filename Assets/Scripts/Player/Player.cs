using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerFire))]
[RequireComponent(typeof(PlayerCollision))]
[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerIFrames))]
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
    internal PlayerCollision playerCollision;
    internal PlayerHealth playerHealth;
    internal PlayerIFrames playerIFrames;
    internal PlayerFX playerFX;

    //CACHED COMPONENT REFERENCES
    internal Rigidbody rigidBody;
    internal BoxCollider boxCollider;
    internal MeshRenderer meshRenderer;

    //CACHED EXTERNAL REFERENCES
    internal HealthDisplay healthDisplay;
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
        playerCollision = GetComponent<PlayerCollision>();
        playerHealth = GetComponent<PlayerHealth>();
        playerIFrames = GetComponent<PlayerIFrames>();
        playerFX = GetComponent<PlayerFX>();

        rigidBody = GetComponentInChildren<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        meshRenderer = GetComponent<MeshRenderer>();

        healthDisplay = FindObjectOfType<HealthDisplay>();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    private void StartCustomStarts()
    {
        playerInput.CustomStart();
        playerMovement.CustomStart();
        playerFire.CustomStart();
        playerCollision.CustomStart();
        playerHealth.CustomStart();
        playerIFrames.CustomStart();
        playerFX.CustomStart();
    }
}