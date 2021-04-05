using UnityEngine;

[RequireComponent(typeof(Obstacle))]
public class ObstacleFX : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] GameObject damageVFX;
    [SerializeField] GameObject deathVFX;

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
}