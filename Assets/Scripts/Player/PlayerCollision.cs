using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerCollision : MonoBehaviour
{
    //REFERENCED CACHED CLASSES
    Player player;

    //STATE
    bool collisionsEnabled = true;

    internal void CustomStart()
    {
        player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"{this.name}--collided with--{other.gameObject.transform.parent.name}");
        player.playerHealth.ManageDamage();
    }



    //FOR DEBUG BUILD
    internal void ToggleCollision()
    {
        collisionsEnabled = !collisionsEnabled;
        player.boxCollider.enabled = collisionsEnabled;
        Debug.Log($"Are collisions enabled? {collisionsEnabled}");
    }
}