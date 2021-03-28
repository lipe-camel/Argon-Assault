using UnityEngine;

[RequireComponent(typeof(Asteroid))]
public class AsteroidRandomness : MonoBehaviour
{
    //CONFIG PARAMS
    [Header("Rotation")]
    [SerializeField] float rotationFactor = 5f;
    [SerializeField] float initialRotation = 15f;
    [Header("Scale")]
    [SerializeField] float minSize = 1;
    [SerializeField] float maxSize = 5f;

    //STATE
    float rndmPitch, rndmYaw, rndmRoll;

    //CACHED CLASSES REFERENCES
    Asteroid asteroid;

    //CACHED REFERENCES
    Transform asteroidTransform;


    internal void CustomStart()
    {
        asteroid = GetComponent<Asteroid>();
        asteroidTransform = asteroid.asteroidModel.transform;

        SetRandomRotationFactor();
        SetInitialRotation();
        SetAsteroidSize();
    }

    private void Update()
    {
        Rotate();
    }


    //ROTATION
    private void SetRandomRotationFactor()
    {
        rndmPitch = Random.Range(-rotationFactor, rotationFactor);
        rndmYaw = Random.Range(-rotationFactor, rotationFactor);
        rndmRoll = Random.Range(-rotationFactor, rotationFactor);
    }

    private void SetInitialRotation()
    {
        float rndmX = Random.Range(-initialRotation, initialRotation);
        float rndmY = Random.Range(-initialRotation, initialRotation);
        float rndmZ = Random.Range(-initialRotation, initialRotation);

        asteroidTransform.rotation = Quaternion.Euler(rndmX, rndmY, rndmZ);
    }

    private void Rotate()
    {
        asteroidTransform.Rotate(new Vector3(rndmPitch, rndmYaw, rndmRoll), Space.Self);
    }


    //SCALE
    private void SetAsteroidSize()
    {
        float rndmSize = Random.Range(minSize, maxSize);

        asteroidTransform.localScale = new Vector3(rndmSize, rndmSize, rndmSize);
    }
}