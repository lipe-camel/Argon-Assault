using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    [TextArea(20, 30)] [SerializeField] string DebuggerNotes;

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
                Debug.Log($"Are collisions enabled? {player.playerCollision.collisionsEnabled}");
            }

            //Kill the player
            if (Input.GetKeyDown(KeyCode.K))
            {
                player.playerHealth.Die();
                Debug.Log("The player is DEAD! F's in the chat bois");
            }

            //Adds a life to the player            
            if (Input.GetKeyDown(KeyCode.L))
            {
                player.playerHealth.GainHealth();
                Debug.Log("Player life restored, now THAT'S cheating");
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

            //Destroy all obstacles
            if (Input.GetKeyDown(KeyCode.B))
            {
                obstacles = FindObjectsOfType<Obstacle>();
                foreach (Obstacle obstacle in obstacles)
                {
                    obstacle.obstacleHealth.Die();
                }
                Debug.Log($"All obstacles destroyed");
            }

        }
    }
}
