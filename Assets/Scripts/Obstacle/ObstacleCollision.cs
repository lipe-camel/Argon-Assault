using UnityEngine;

[RequireComponent(typeof(Obstacle))]
public class ObstacleCollision : MonoBehaviour
{
    //CACHED CLASSES REFERENCES
    Obstacle obstacle;


    internal void CustomStart()
    {
        obstacle = GetComponent<Obstacle>();
    }


    private void OnParticleCollision(GameObject other)
    {
        Debug.Log($"{this.gameObject.name} collided with {other.gameObject.name}");
        obstacle.DestroyThisObstacle();
    }
}