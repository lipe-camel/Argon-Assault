using UnityEngine;

public class ObstacleKiller : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        var obstacle = other.GetComponentInParent<Obstacle>().gameObject;
        if (obstacle)
        {
            Destroy(obstacle);
        }
    }
}