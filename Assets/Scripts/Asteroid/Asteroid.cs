using UnityEngine;

[RequireComponent(typeof(AsteroidRandomness))]
public class Asteroid : MonoBehaviour
{
    [SerializeField] internal GameObject asteroidModel;

    //CACHED CLASSES REFERENCES
    AsteroidRandomness asteroidMovement;

    void Start()
    {
        asteroidMovement = GetComponent<AsteroidRandomness>();
        asteroidMovement.CustomStart();
    }
}