using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerHealth : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] float initialHealth = 1f;

    //STATS
    internal float health;

    //CACHED CLASSES REFERENCES
    Player player;


    internal void CustomStart()
    {
        player = GetComponent<Player>();
        health = initialHealth;
        if (player.healthDisplay)
        {
            player.healthDisplay.UpdateDisplay(health);
        }
    }

    internal void GainHealth()
    {
        health = 1f;
        if (player.healthDisplay)
        {
            player.healthDisplay.UpdateDisplay(health);
        }
    }

    private void LoseHealth(float damage)
    {
        health -= damage;
        if (player.healthDisplay)
        {
            player.healthDisplay.UpdateDisplay(health);
        }
    }

    internal void ManageDamage(float damage)
    {
        LoseHealth(damage);

        if (health > 0.001f)
        {
            StartCoroutine(player.playerIFrames.ManageIframes());
            player.playerSFX.PlayDamageSFX();
            player.playerVFX.PlayDamageVFX();
        }
        else
        {
            player.Despawn();
        }
    }
}