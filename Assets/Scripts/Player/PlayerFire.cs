using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerFire : MonoBehaviour
{
    [SerializeField] float damage = 10f;

    //CACHED CLASSES REFERENCES
    Player player;

    internal void CustomStart()
    {
        player = GetComponent<Player>();
    }

    internal void SetLasersActive(bool isActive)
    {
        foreach (ParticleSystem laser in player.lasers)
        {
            var emissionModule = laser.emission;
            emissionModule.enabled = isActive;
        }
    }

    public float GetDamage()
    {
        return damage;
    }
}