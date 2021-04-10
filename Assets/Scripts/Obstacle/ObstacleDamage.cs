using UnityEngine;

public class ObstacleDamage : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] float damageMultiplier = 10f;

    //INTERNAL CACHED REFERENCES
    Obstacle obstacle;

    internal void CustomStart()
    {
        obstacle = GetComponent<Obstacle>();
    }

    internal float GetDamage()
    {
        return obstacle.obstacleModel.transform.localScale.x / 100 * damageMultiplier;
    }
}