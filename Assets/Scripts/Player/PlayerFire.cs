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
            if (isActive)
            {
                laser.Play();
            }
            else
            {
                laser.Stop();
            }
        }
    }

    internal void ToggleLasers(bool isActive) //used when dead
    {
        foreach (ParticleSystem laser in player.lasers)
        {
            laser.gameObject.SetActive(isActive);
        }
    }

    public float GetDamage()
    {
        return damage;
    }

    internal void CanFire(bool boolean)
    {
        player.canFire = boolean;
    }
}