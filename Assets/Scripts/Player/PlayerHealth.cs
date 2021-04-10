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
        player.healthDisplay.UpdateDisplay(health);
    }

    internal void ManageDamage(float damage)
    {
        LoseHealth(damage);

        if (health > 0.001f)
        {
            StartCoroutine(player.playerIFrames.ManageIframes());
            player.playerFX.PlayDamageVFX();
        }
        else
        {
            Die();
        }
    }

    internal void Die()
    {
        player.isAlive = false;
        //player.rigidBody.useGravity = true;
        player.meshRenderer.enabled = false;
        player.boxCollider.enabled = false;
        player.playerFire.DisableLasers();
        player.playerFX.DisableSecondaryParticles();
        player.playerFX.PlayDeathVFX();
        player.sceneLoader.DeathRestart();
    }
}