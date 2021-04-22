using System.Collections;
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

    internal IEnumerator StartNewGame()
    {
        StartCoroutine(gameState.ShowScreen(GameState.State.GameScreen, gameState.gameScreen, gameState.startSFX));
        gameState.scoreBoard.ResetScore();
        gameState.obstacleSpawner.DespawnAllObstacles();
        gameState.obstacleSpawner.ToggleSpawn(true);
        yield return new WaitForSeconds(gameState.clearScreenTime);
        gameState.player.Spawn();
        gameState.player.playerFire.CanFire(true);
    }
}
