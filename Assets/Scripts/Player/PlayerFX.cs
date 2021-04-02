using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerFX : MonoBehaviour
{
    //CONFIG PARAMS
    [Header("VFX")]
    [SerializeField] internal ParticleSystem damageVFX;
    [SerializeField] internal ParticleSystem deathVFX;

    //CACHED CLASSES REFERENCES
    Player player;


    internal void CustomStart()
    {
        player = GetComponent<Player>();
    }


    internal void PlayDamageVFX()
    {
        PlayVFX(damageVFX);
    }

    internal void PlayDeathVFX()
    {
        PlayVFX(deathVFX);
    }

    private void PlayVFX(ParticleSystem vfxPrefab)
    {
        vfxPrefab.Play();
    }
}