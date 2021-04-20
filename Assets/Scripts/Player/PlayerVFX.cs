using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerVFX : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] internal GameObject damageVFX;
    [SerializeField] internal GameObject deathVFX;
    [SerializeField] internal ParticleSystem[] secondaryParticles;

    //CACHED EXTERNAL REFERENCES
    GameObject particlesHolder;

    //CACHED STRING REFERENCES
    const string PARTICLE_HOLDER_GM_OBJ = "Particles Holder";


    internal void CustomStart()
    {
        FindParticlesHolder();
    }


    internal void PlayDamageVFX()
    {
        InstantiateVFX(damageVFX, transform.position);
    }

    internal void PlayDeathVFX()
    {
        InstantiateVFX(deathVFX, transform.position);
    }


    private void InstantiateVFX(GameObject prefabVFX, Vector3 instantiatePos)
    {
        if (!prefabVFX) { return; }

        //instantiate in the particles holder parent
        GameObject vfx = Instantiate(prefabVFX, instantiatePos, Quaternion.identity);
        vfx.transform.parent = particlesHolder.transform;

        //destroy after is finished
        var duration = vfx.GetComponent<ParticleSystem>().main.duration * 10;
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

    internal void DisableSecondaryParticles()
    {
        if(secondaryParticles.Length == 0) { return; }

        foreach (ParticleSystem particle in secondaryParticles)
        {
            Destroy(particle.gameObject);
        }
    }
}