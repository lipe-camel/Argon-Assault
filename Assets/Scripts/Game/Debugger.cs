using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    [TextArea(20, 30)] [SerializeField] string DebuggerNotes;

    Obstacle[] obstacles;


    private void Update()
    {
        ManageDebugInputs();
    }


    private void ManageDebugInputs()
    {
        if (Debug.isDebugBuild)
        {

            //Toggle the player collisions
            if (Input.GetKeyDown(KeyCode.G))
            {
                FindObjectOfType<Player>().playerCollision.ToggleCollision();
                Debug.Log($"Are collisions enabled? {FindObjectOfType<Player>().playerCollision.collisionsEnabled}");
            }

            //Kill the player
            if (Input.GetKeyDown(KeyCode.K))
            {
                FindObjectOfType<Player>().Despawn();
                Debug.Log("The player is DEAD! F's in the chat bois");
            }

            //Adds a life to the player            
            if (Input.GetKeyDown(KeyCode.L))
            {
                FindObjectOfType<Player>().playerHealth.GainHealth();
                Debug.Log("Player life restored, now THAT'S cheating");
            }

            //Adds A LOT of life to the current obstacles
            if (Input.GetKeyDown(KeyCode.J))
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
                FindObjectOfType<ObstacleSpawner>().DespawnAllObstacles();
                Debug.Log($"All obstacles destroyed");
            }

        }
    }
}
