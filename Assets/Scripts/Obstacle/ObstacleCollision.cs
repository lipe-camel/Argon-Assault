using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Obstacle))]
public class ObstacleCollision : MonoBehaviour
{
    //CACHED CLASSES REFERENCES
    Obstacle obstacle;
    List<ParticleCollisionEvent> collisionEvents;
    [SerializeField] GameObject testobject;


    internal void CustomStart()
    {
        obstacle = GetComponent<Obstacle>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }


    private void OnParticleCollision(GameObject other)
    {
        //Debug.Log($"{this.gameObject.name} collided with {other.gameObject.name}");
        float damage = other.GetComponentInParent<PlayerFire>().GetDamage();

        ParticleSystem particleSystem = other.GetComponent<ParticleSystem>();
        ParticlePhysicsExtensions.GetCollisionEvents(particleSystem, this.gameObject, collisionEvents);
        EmitatLocation(collisionEvents[0]);
        

        obstacle.obstacleHealth.ManageDamage(damage);
    }

    void EmitatLocation(ParticleCollisionEvent particleCollisionEvent)
    {
        var pos = particleCollisionEvent.intersection;
        var rot = Quaternion.LookRotation(particleCollisionEvent.normal);
        Instantiate(testobject, pos, rot);
    }
}




//Vector3 intersectionPoint;
//ParticleSystem particleSystem = other.GetComponent<ParticleSystem>();
//int numcollisionevent = ParticlePhysicsExtensions.GetCollisionEvents(particleSystem, other, collisionevents);
//for (int i = 0; i < numcollisionevent; i++)
//{
//    intersectionPoint = collisionevents[i].intersection;
//    Debug.Log(intersectionPoint);
//}