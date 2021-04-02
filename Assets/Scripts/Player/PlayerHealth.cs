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
    }

    private void Die()
    {
        hearts--;
        player.isAlive = false;
        player.rigidBody.useGravity = true;
        Debug.Log("player should die now");
        player.sceneLoader.DeathRestart();
    }
}