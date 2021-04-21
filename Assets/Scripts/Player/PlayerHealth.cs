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
    }

    internal void GainHealth()
    {
        health = 1f;
        player.healthDisplay.UpdateDisplay(health);
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
            Die();
        }
    }

    internal void Die()
    {
        player.playerSFX.PlayDeathSFX();
        player.playerVFX.PlayDeathVFX();
        player.isAlive = false;
        player.meshRenderer.enabled = false;
        player.boxCollider.enabled = false;
        player.playerFire.ToggleLasers(false);
        player.playerVFX.ToggleSecondaryParticles(false);
        StartCoroutine(player.gameState.ShowEndScreen());
    }

    internal void Spawn()
    {
        player.isAlive = true;
        player.meshRenderer.enabled = true;
        player.boxCollider.enabled = true;
        player.playerFire.ToggleLasers(true);
        player.playerVFX.ToggleSecondaryParticles(true);
    }
}