using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerHealth : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] int initialHearts = 3;

    //STATS
    int hearts;

    //CACHED CLASSES REFERENCES
    Player player;


    internal void CustomStart()
    {
        player = GetComponent<Player>();
        hearts = initialHearts;
    }

    internal void ManageDamage()
    {
        if(hearts > 1)
        {
            LoseHeart();
        }
        else
        {
            Die();
        }
    }

    private void LoseHeart()
    {
        hearts--;
        player.playerFX.PlayDamageVFX();
    }

    private void Die()
    {
        hearts--;
        player.isAlive = false;
        player.rigidBody.useGravity = true;
        player.playerFX.PlayDeathVFX();
        player.sceneLoader.DeathRestart();
    }
}