using UnityEngine;

[RequireComponent(typeof(GameState))]
internal class StartGame : MonoBehaviour
{
    //CACHED INTERNAL REFERENCES
    GameState gameState;


    internal void CustomStart()
    {
        gameState = GetComponent<GameState>();
    }

    internal void StartNewGame()
    {
        StartCoroutine(gameState.ShowScreen(GameState.State.GameScreen, gameState.gameScreen, gameState.startSFX));
        foreach (GameObject gameElement in gameState.gameElements)
        {
            gameElement.SetActive(true);
        }
        gameState.obstacleSpawner.Spawn(true);
        gameState.player.playerHealth.Spawn();

    }
}
