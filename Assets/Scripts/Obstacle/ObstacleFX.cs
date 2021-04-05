using System.Collections.Generic;
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
    [SerializeField] float minVelocity = 5f;

    [SerializeField] float timeToDestroy = 2f;

    //CACHED CLASSES REFERENCES
    Obstacle obstacle;

    //CACHED EXTERNAL REFERENCES
    GameObject particlesHolder;

    //CACHED STRING REFERENCES
    const string PARTICLE_HOLDER_GM_OBJ = "Particles Holder";



    //START
    internal void CustomStart()
    {
        obstacle = GetComponent<Obstacle>();
        FindParticlesHolder();
    }


    //PARTICLES
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



    //EXPLOSION
    internal void Explode(Vector3 instantiatePos)
    {
        StopParticleEmission();
        InstantiateLittlePieces();
        DisableComponents();
        InstantiateVFX(deathVFX, instantiatePos);

        Destroy(this.gameObject, timeToDestroy);
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
                Quaternion.Euler(obstacle.obstacleRandomness.GetRandomRotation(rotFlutuation)));
            obstacle.obstacleRandomness.SetModelSize(littlePart, minPieceSize, maxPieceSize);
            littlePart.transform.parent = transform;
            littlePart.gameObject.name = $"littlePart ({numberOfParts})";

            //apply velocity
            Rigidbody rigidbody = littlePart.AddComponent<Rigidbody>();
            rigidbody.useGravity = false;
            rigidbody.velocity = obstacle.obstacleRandomness.GetRandomVelocity(velocityFlutuation, minVelocity);

            //shink in size untill size 0
            littlePart.AddComponent<ShrinkPiece>();

            numberOfParts--;
        }
    }
}