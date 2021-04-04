using UnityEngine;

[RequireComponent(typeof(Obstacle))]
public class ObstacleFX : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] GameObject damageVFX;
    [SerializeField] GameObject deathVFX;

    //CACHED CLASSES REFERENCES
    Obstacle obstacle;


    internal void CustomStart()
    {
        obstacle = GetComponent<Obstacle>();
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
        GameObject vfx = Instantiate(prefabVFX, instantiatePos, Quaternion.identity);
        var duration = vfx.GetComponent<ParticleSystem>().main.duration;
        Destroy(vfx, duration);
    }
}