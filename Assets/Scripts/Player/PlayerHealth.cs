using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerHealth : MonoBehaviour
{
    //CONFIG PARAMS
    [Header("Health")]
    [SerializeField] float initialHealth = 1f;
    [Header("I Frames")]
    [SerializeField] int numberOfFlashes = 10;
    [SerializeField] float flashDuration = 0.1f;

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
            StartCoroutine(ManageIframes());
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
        player.rigidBody.useGravity = true;
        player.boxCollider.enabled = false;
        player.playerFire.DisableLasers();
        player.playerFX.PlayDeathVFX();
        player.sceneLoader.DeathRestart();
    }


    //I FRAMES
    internal IEnumerator ManageIframes()
    {
        int temp = 0;
        player.boxCollider.enabled = false;
        Debug.Log($"{this.name} colliders are enabled? {player.boxCollider.enabled}");
        while (temp < numberOfFlashes)
        {
            player.meshRenderer.enabled = false;
            yield return new WaitForSeconds(flashDuration);
            player.meshRenderer.enabled = true;
            yield return new WaitForSeconds(flashDuration);
            temp++;
        }
        player.boxCollider.enabled = true;
        Debug.Log($"{this.name} colliders are enabled? {player.boxCollider.enabled}");
    }
}