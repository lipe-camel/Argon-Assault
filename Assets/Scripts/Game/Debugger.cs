using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    //CACHED EXTERNAL REFERENCES
    Player player;
    Obstacle[] obstacles;


    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        ManageDebugInputs();
    }


    private void ManageDebugInputs()
    {
        if (Debug.isDebugBuild)
        {

            //Toggle the player collisions
            if (Input.GetKeyDown(KeyCode.C))
            {
                player.playerCollision.ToggleCollision();
            }

            //Kill the player
            if (Input.GetKeyDown(KeyCode.K))
            {
                player.playerHealth.Die();
            }

            //Adds a life to the player            
            if (Input.GetKeyDown(KeyCode.L))
            {
                player.playerHealth.GainHeart();
            }

            //Adds A LOT of life to the current obstacles
            if (Input.GetKeyDown(KeyCode.P))
            {
                obstacles = FindObjectsOfType<Obstacle>();
                foreach (Obstacle obstacle in obstacles)
                {
                    obstacle.obstacleHealth.TurnIndestructible(69420);
                    Debug.Log($"new {obstacle.gameObject.name} health: {obstacle.obstacleHealth.health}");
                }
            }
        }
    }
}
