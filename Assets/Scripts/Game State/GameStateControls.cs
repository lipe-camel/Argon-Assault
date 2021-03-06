﻿using UnityEngine;

internal class GameStateControls : MonoBehaviour
{
    //INTERNAL CACHED REFERENCES
    GameState gameState;

    internal void CustomStart()
    {
        gameState = GetComponent<GameState>();
    }

    private void Update()
    {
        //MENU CONTROLS
        if (gameState.currentState == GameState.State.TitleScreen)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(gameState.ShowScreen(
                    GameState.State.TutorialScreen, gameState.tutorialScreen, gameState.clickSFX));
            }
        }

        if (gameState.currentState == GameState.State.TutorialScreen)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(gameState.StartGame());
            }
        }

        if (gameState.currentState == GameState.State.EndScreen)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(gameState.StartGame());
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                StartCoroutine(gameState.ShowScreen(
                    GameState.State.CreditsScreen, gameState.creditsScreen, gameState.clickSFX));
            }
        }

        if (gameState.currentState == GameState.State.CreditsScreen)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(gameState.StartGame());
            }
        }

        //PAUSE CONTROLS
        if (gameState.currentState == GameState.State.GameScreen)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                StartCoroutine(gameState.PauseGame());
            }
        }

        if (gameState.currentState == GameState.State.PauseScreen)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                StartCoroutine(gameState.ResumeGame());
            }
        }
    }
}