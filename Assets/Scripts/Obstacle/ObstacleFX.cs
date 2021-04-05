using UnityEngine;

[RequireComponent(typeof(Obstacle))]
public class ObstacleFX : MonoBehaviour
{
    //CONFIG PARAMS
    [Header("Particles to Instantiate")]
    [SerializeField] GameObject damageVFX;
    [SerializeField] GameObject deathVFX;
    [Header("Explosion")]
    [SerializeField] int minNumOfPieces = 5;
    [SerializeField] int maxNumOfPieces = 8;

    [SerializeField] float posFlutuation = 5f;

    [SerializeField] float rotFlutuation = 15f;

    [SerializeField] float minPieceSize= 0.1f;
    [SerializeField] float maxPieceSize = 1f;

    [SerializeField] float velocityFlutuation = 10f;


    //CACHED CLASSES REFERENCES
    Obstacle obstacle;

    //CACHED EXTERNAL REFERENCES
    GameObject particlesHolder;

    //CACHED STRING REFERENCES
    const string PARTICLE_HOLDER_GM_OBJ = "Particles Holder";

    internal void CustomStart()
    {
        obstacle = GetComponent<Obstacle>();
        FindParticlesHolder();
    }

    private void FindParticlesHolder()
    {
        particlesHolder = GameObject.Find(PARTICLE_HOLDER_GM_OBJ);
        if (!particlesHolder)
        {
            particlesHolder = new GameObject(PARTICLE_HOLDER_GM_OBJ);
        }
    }


    internal void PlayDamageVFX(Vector3 instantiatePos)
    {
        InstantiateVFX(damageVFX, instantiatePos);
    }

    internal void PlayDeathVFX(Vector3 instantiatePos)
    {
        InstantiateVFX(deathVFX, instantiatePos);
    }

    private void InstantiateVFX(GameObject prefabVFX, Vector3 instantiatePos)
    {
        if (!prefabVFX) { return; }

        //instantiate in the particles holder parent
        GameObject vfx = Instantiate(prefabVFX, instantiatePos, Quaternion.identity);
        vfx.transform.parent = particlesHolder.transform;

        //destroy after is finished
        var duration = vfx.GetComponent<ParticleSystem>().main.duration * 2;
        Destroy(vfx, duration);
    }

    internal void Explode(Vector3 instantiatePos)
    {
        StopParticleEmission();
        InstantiateLittlePieces();
        DisableComponents();
        InstantiateVFX(deathVFX, instantiatePos);

        //destroy game object
    }

    private void DisableComponents()
    {
        //Disable the BoxCollider and MeshRenderer
        BoxCollider boxCollider = obstacle.obstacleModel.GetComponentInChildren<BoxCollider>();
        MeshRenderer meshRenderer = obstacle.obstacleModel.GetComponent<MeshRenderer>();
        boxCollider.enabled = false;
        meshRenderer.enabled = false;
    }

    private void StopParticleEmission()
    {
        ParticleSystem particleSystem = obstacle.obstacleModel.GetComponentInChildren<ParticleSystem>();
        var main = particleSystem.main;
        main.maxParticles = 0;
    }

    private void InstantiateLittlePieces()
    {
        int numberOfParts = Random.Range(minNumOfPieces, maxNumOfPieces);
        while (numberOfParts > 0)
        {
            //Instantiate with randomized transform and new name
            var littlePart = Instantiate(obstacle.obstacleModel,
                obstacle.obstacleRandomness.GetRandomPos(posFlutuation),
                Quaternion.Euler(obstacle.obstacleRandomness.GetRandomizedV3(rotFlutuation)));
            obstacle.obstacleRandomness.SetModelSize(littlePart, minPieceSize, maxPieceSize);
            littlePart.transform.parent = transform;
            littlePart.gameObject.name = $"littlePart ({numberOfParts})";

            Rigidbody rigidbody = littlePart.AddComponent<Rigidbody>();
            rigidbody.useGravity = false;
            rigidbody.velocity = obstacle.obstacleRandomness.GetRandomizedV3(velocityFlutuation);

            numberOfParts--;

            //while this number is bigger than zero, instantiate a game object near the vector 3

            //create/remove the (un)necessary components
            //apply a random velocity
            //shink in size untill size 0

        }
    }

    

}