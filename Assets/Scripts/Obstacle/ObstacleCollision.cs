using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Obstacle))]
public class ObstacleCollision : MonoBehaviour
{
    //CACHED CLASSES REFERENCES
    Obstacle obstacle;
    List<ParticleCollisionEvent> collisionEvents;


    internal void CustomStart()
    {
        obstacle = GetComponent<Obstacle>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }


    private void OnParticleCollision(GameObject other)
    {
        //Get the damage value
        float damage = other.GetComponentInParent<PlayerFire>().GetDamage();

        //Get the intersection position
        ParticleSystem particleSystem = other.GetComponent<ParticleSystem>();
        ParticlePhysicsExtensions.GetCollisionEvents(particleSystem, this.gameObject, collisionEvents);

        obstacle.obstacleHealth.ManageDamage(damage, collisionEvents[0].intersection);
    }
}