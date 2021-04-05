using UnityEngine;

[RequireComponent(typeof(Obstacle))]
public class ObstacleHealth : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] [Tooltip("The value to be multiplied by the obstacle randomized size")]
    float healthBaseValue = 10f;

    //STATS
    internal float health;

    //CACHED CLASSES REFERENCES
    Obstacle obstacle;


    internal void CustomStart()

    {
        obstacle = GetComponent<Obstacle>();
        health = healthBaseValue * obstacle.obstacleRandomness.rndmSize;
    }

    internal void ManageDamage(float damage, Vector3 instantiatePos)
    {
        health -= damage;
        if(health >= 0)
        {
            LoseHealth(instantiatePos);
        }
        else
        {
            Die();
        }
    }

    private void LoseHealth(Vector3 instantiatePos)
    {
        obstacle.obstacleFX.PlayDamageVFX(instantiatePos);
        obstacle.obstacleMovement.DecreaseSpeed();
    }

    private void Die()
    {
        obstacle.scoreBoard.AddToScore(obstacle.obstacleScore.GetobstacleScoreValue());
        obstacle.obstacleFX.Explode(transform.position);
    }



    //FOR DEBUG BUILD
    internal void TurnIndestructible(float indestructiblility)
    {
        health += indestructiblility;
    }
}