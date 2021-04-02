using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerFire))]
[RequireComponent(typeof(PlayerCollision))]
[RequireComponent(typeof(PlayerHealth))]
public class Player : MonoBehaviour
{
    //INSPECTOR REFERENCES
    [SerializeField] internal ParticleSystem[] lasers;

    //CACHED CLASSES REFERENCES
    internal PlayerInput playerInput;
    internal PlayerMovement playerMovement;
    internal PlayerFire playerFire;
    internal PlayerCollision playerColision;
    internal PlayerHealth playerHealth;

    //CACHED COMPONENT REFERENCES
    internal Rigidbody rigidBody;

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

        rigidBody = GetComponentInChildren<Rigidbody>();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    private void StartCustomStarts()
    {
        playerInput.CustomStart();
        playerMovement.CustomStart();
        playerFire.CustomStart();
        playerColision.CustomStart();
        playerHealth.CustomStart();
    }
}