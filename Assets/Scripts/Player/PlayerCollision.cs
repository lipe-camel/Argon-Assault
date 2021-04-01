using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerCollision : MonoBehaviour
{
    //REFERENCED CACHED CLASSES
    Player player;


    internal void CustomStart()
    {
        player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"{this.name}--collided with--{other.gameObject.transform.parent.name}");
    }
}