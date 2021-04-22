using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerFire))]
[RequireComponent(typeof(PlayerCollision))]
[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerIFrames))]
[RequireComponent(typeof(PlayerVFX))]
[RequireComponent(typeof(PlayerSFX))]
public class Player : MonoBehaviour
{
    //INSPECTOR REFERENCES
    [SerializeField] internal ParticleSystem[] lasers;

    //STATES
    internal bool isAlive = true;
    internal bool canMove;
    internal bool canFire;

    //CACHED CLASSES REFERENCES
    internal PlayerInput playerInput;
    internal PlayerMovement playerMovement;
    internal PlayerFire playerFire;
    internal PlayerCollision playerCollision;
    internal PlayerHealth playerHealth;
    internal PlayerIFrames playerIFrames;
    internal PlayerVFX playerVFX;
    internal PlayerSFX playerSFX;

    //CACHED COMPONENT REFERENCES
    internal Rigidbody rigidBody;
    internal BoxCollider boxCollider;
    internal MeshRenderer meshRenderer;
    internal AudioSource audioSource;

    //CACHED EXTERNAL REFERENCES
    internal HealthDisplay healthDisplay;
    internal SceneLoader sceneLoader;
    internal GameState gameState;
    internal CameraShaker cameraShaker;

    void Start()
    {
        GetCachedReferences();
        StartCustomStarts();
    }

    internal void GetCachedReferences()
    {
        playerInput = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();
        playerFire = GetComponent<PlayerFire>();
        playerCollision = GetComponent<PlayerCollision>();
        playerHealth = GetComponent<PlayerHealth>();
        playerIFrames = GetComponent<PlayerIFrames>();
        playerVFX = GetComponent<PlayerVFX>();
        playerSFX = GetComponent<PlayerSFX>();

        rigidBody = GetComponentInChildren<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        meshRenderer = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();

        healthDisplay = FindObjectOfType<HealthDisplay>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameState = FindObjectOfType<GameState>();
        cameraShaker = FindObjectOfType<CameraShaker>();
    }

    internal void StartCustomStarts()
    {
        playerInput.CustomStart();
        playerMovement.CustomStart();
        playerFire.CustomStart();
        playerCollision.CustomStart();
        playerHealth.CustomStart();
        playerIFrames.CustomStart();
        playerVFX.CustomStart();
        playerSFX.CustomStart();
    }


    internal void Despawn()
    {
        playerSFX.PlayDeathSFX();
        playerVFX.PlayDeathVFX();
        audioSource.Stop();
        isAlive = false;
        meshRenderer.enabled = false;
        boxCollider.enabled = false;
        playerFire.ToggleLasers(false);
        playerVFX.ToggleSecondaryParticles(false);
        StartCoroutine(gameState.ShowEndScreen());
    }

    internal void Spawn()
    {
        if (isAlive) { return; }

        //this power starts the player prefab
        gameObject.SetActive(true);
        GetCachedReferences();
        StartCustomStarts();

        playerMovement.ResetPosition();
        audioSource.Play();
        isAlive = true;
        meshRenderer.enabled = true;
        boxCollider.enabled = true;
        playerFire.ToggleLasers(true);
        playerVFX.ToggleSecondaryParticles(true);
        StartCoroutine(playerIFrames.ManageIframes());
    }
}