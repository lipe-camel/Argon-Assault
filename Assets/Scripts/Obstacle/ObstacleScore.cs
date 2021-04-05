using UnityEngine;

[RequireComponent(typeof(Obstacle))]
public class ObstacleScore : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField][Tooltip("To be multiplied by the obstacle randomized size")]
    int baseScore = 10;

    //CACHED CLASSES REFERENCES
    Obstacle obstacle;

    internal void CustomStart()
    {
        obstacle = GetComponent<Obstacle>();
    }

    internal int GetobstacleScoreValue()
    {
        return Mathf.FloorToInt(baseScore * obstacle.obstacleModel.transform.localScale.x);
    }
}