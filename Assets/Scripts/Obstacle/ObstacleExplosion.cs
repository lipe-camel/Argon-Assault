using UnityEngine;
    
internal class ObstacleExplosion : MonoBehaviour
{
    //CONFIG PARAMS
    [Header("Pieces Quantity")]
    [SerializeField] int minNumOfPieces = 5;
    [SerializeField] int maxNumOfPieces = 8;
    [Header("Position")]
    [SerializeField] float posFlutuation = 5f;
    [Header("Rotation")]
    [SerializeField] float rotFlutuation = 15f;
    [Header("Scale")]
    [SerializeField] float minPieceSize = 0.1f;
    [SerializeField] float maxPieceSize = 1f;
    [Header("Velocity")]
    [SerializeField] float velocityFlutuation = 10f;
    [SerializeField] float minVelocity = 5f;
    [Header("Time")]
    [SerializeField] float timeToDestroy = 2f;

    //CACHED CLASSES REFERENCES
    Obstacle obstacle;


    //START
    internal void CustomStart()
    {
        obstacle = GetComponent<Obstacle>();
    }


    //EXPLOSION
    internal void Explode(Vector3 instantiatePos)
    {
        StopParticleEmission();
        InstantiateLittlePieces();
        DisableComponents();
        obstacle.obstacleParticles.PlayDeathVFX(instantiatePos);
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
        if (!particleSystem) { return; }
        var main = particleSystem.main;
        main.maxParticles = 0;
    }

    private void InstantiateLittlePieces()
    {
        int numberOfParts = Random.Range(minNumOfPieces, maxNumOfPieces);
        while (numberOfParts > 0)
        {
            //Instantiate with randomized position and rotation
            var littlePart = Instantiate(obstacle.obstacleModel,
                obstacle.obstacleRandomness.GetRandomPos(posFlutuation),
                Quaternion.Euler(obstacle.obstacleRandomness.GetRandomRotation(rotFlutuation)));

            //randomize scale base on original size
            float rndmScale = obstacle.obstacleRandomness.GetRandomScale(minPieceSize, maxPieceSize) * 
                obstacle.obstacleModel.transform.localScale.x;
            littlePart.transform.localScale = new Vector3(rndmScale, rndmScale, rndmScale);

            //Organize in the correct parent and rename
            littlePart.transform.parent = transform;
            littlePart.gameObject.name = $"littlePart ({numberOfParts})";

            //apply velocity
            Rigidbody rigidbody = littlePart.AddComponent<Rigidbody>();
            //rigidbody.useGravity = false;
            rigidbody.velocity = obstacle.obstacleRandomness.GetRandomVelocity(velocityFlutuation, minVelocity);

            //shink in size untill size 0
            littlePart.AddComponent<ShrinkPiece>();

            numberOfParts--;
        }
    }
}