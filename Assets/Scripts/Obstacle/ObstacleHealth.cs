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
        health = healthBaseValue * obstacle.obstacleModel.transform.localScale.x;
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
        obstacle.obstacleParticles.PlayDamageVFX(instantiatePos);
        obstacle.obstacleMovement.DecreaseSpeed();
    }

    internal void Die()
    {
        obstacle.scoreBoard.AddToScore(obstacle.obstacleScore.GetobstacleScoreValue());
        obstacle.obstacleExplosion.Explode(transform.position);
    }



    //FOR DEBUG BUILD
    internal void TurnIndestructible(float indestructiblility)
    {
        health += indestructiblility;
    }
}