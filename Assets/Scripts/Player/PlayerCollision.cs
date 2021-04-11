using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerCollision : MonoBehaviour
{
    //REFERENCED CACHED CLASSES
    Player player;

    //STATE
    internal bool collisionsEnabled = true;

    internal void CustomStart()
    {
        player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponentInParent<Obstacle>()) { return; }

        float damage = other.GetComponentInParent<Obstacle>().obstacleDamage.GetDamage();
        player.playerHealth.ManageDamage(damage);

        //Debug.Log($"{this.name} collided with {other.gameObject.transform.parent.parent.name} and suffered {damage} damage. Life now is {player.playerHealth.health}");
    }



    //FOR DEBUG BUILD
    internal void ToggleCollision()
    {
        collisionsEnabled = !collisionsEnabled;
        player.boxCollider.enabled = collisionsEnabled;
    }
}