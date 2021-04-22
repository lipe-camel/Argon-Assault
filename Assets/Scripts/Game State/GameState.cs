using System.Collections;
using UnityEngine;

public class GameState : MonoBehaviour
{
    //CONFIG PARAMS
    [Header("Game")]
    [SerializeField] internal Player player;
    [SerializeField] internal ObstacleSpawner obstacleSpawner;
    [SerializeField] internal ScoreBoard scoreBoard;

    [Header("Screens")]
    [SerializeField] internal GameObject splashScreen;
    [SerializeField] internal GameObject titleScreen, tutorialScreen, gameScreen, pauseScreen, endScreen, creditsScreen;

    [Header("Time")]
    [SerializeField] internal float clearScreenTime = 0.25f;
    [SerializeField] float splashScreenTime = 2f, deathTime = 2f;

    [Header("Audio")]
    [SerializeField] float SFXVolume = 0.4f;
    [SerializeField] internal AudioClip splashSFX, clickSFX, titleSFX, startSFX;

    //STATE
    internal enum State { SplashScreen, TitleScreen, TutorialScreen, GameScreen, PauseScreen, EndScreen, CreditsScreen};
    internal State currentState;
    internal GameObject currentScreen;

    //CACHED INTERNAL REFERENCES
    internal GameStateControls gameStateControls;


    //START
    private void Start()
    {
        ManageClasses();
        DeactivateAllScreens();
        SetPreGame();
        StartCoroutine(ShowSplashScreen());
    }

    private void ManageClasses()
    {
        gameStateControls = GetComponent<GameStateControls>();
        gameStateControls.CustomStart();
    }

    private void DeactivateAllScreens()
    {
        splashScreen.SetActive(false);
        titleScreen.SetActive(false);
        tutorialScreen.SetActive(false);
        gameScreen.SetActive(false);
        pauseScreen.SetActive(false);
        endScreen.SetActive(false);
        creditsScreen.SetActive(false);
    }

    private void SetPreGame()
    {
        obstacleSpawner.ToggleSpawn(false);
        player.playerMovement.SetMenuPosition();
        player.playerFire.CanFire(false);
    }


    //MANAGE SCREENS
    internal IEnumerator ShowScreen(State state, GameObject screen, AudioClip SFX)
    {
        AudioSource.PlayClipAtPoint(SFX, Camera.main.transform.position, SFXVolume);

        currentScreen.SetActive(false);
        yield return new WaitForSeconds(clearScreenTime);
        currentState = state;
        currentScreen = screen;
        currentScreen.SetActive(true);
    }


    internal IEnumerator ShowSplashScreen()
    {
        splashScreen.SetActive(true);
        currentScreen = splashScreen;
        currentState = State.SplashScreen;
        player.playerMovement.CanMove(true);

        yield return new WaitForSeconds(splashScreenTime /8);
        AudioSource.PlayClipAtPoint(splashSFX, Camera.main.transform.position, SFXVolume);
        yield return new WaitForSeconds(splashScreenTime * 7/8);

        StartCoroutine(ShowScreen(State.TitleScreen, titleScreen, titleSFX));
    }

    public IEnumerator ShowEndScreen()
    {
        yield return new WaitForSeconds(deathTime);

        currentScreen.SetActive(false);
        currentState = State.EndScreen;
        currentScreen = endScreen;
        endScreen.SetActive(true);
        scoreBoard.ShowFinalScore();
        obstacleSpawner.ToggleSpawn(false);
    }

    internal IEnumerator StartGame()
    {
        StartCoroutine(ShowScreen(State.GameScreen, gameScreen, startSFX));
        scoreBoard.ResetScore();
        obstacleSpawner.DespawnAllObstacles();
        yield return new WaitForSeconds(clearScreenTime);
        obstacleSpawner.ToggleSpawn(true);
        player.Spawn();
        player.playerFire.CanFire(true);
        player.playerMovement.CanMove(true);
    }

    internal IEnumerator PauseGame()
    {
        Debug.Log("Game should pause now");

        AudioSource.PlayClipAtPoint(clickSFX, Camera.main.transform.position, SFXVolume);
        FindObjectOfType<Music>().GetComponent<AudioReverbFilter>().enabled = true;
        player.audioSource.enabled = false;

        player.playerFire.CanFire(false);
        player.playerMovement.CanMove(false);

        yield return new WaitForSeconds(0.0001f);
        Time.timeScale = 0f;

        currentScreen = pauseScreen;
        pauseScreen.SetActive(true);
        currentState = State.PauseScreen;
    }

    internal IEnumerator ResumeGame()
    {
        Debug.Log("Game should resume now");

        AudioSource.PlayClipAtPoint(clickSFX, Camera.main.transform.position, SFXVolume);
        FindObjectOfType<Music>().GetComponent<AudioReverbFilter>().enabled = false;
        player.audioSource.enabled = true;

        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.0001f);

        player.playerFire.CanFire(true);
        player.playerMovement.CanMove(true);

        currentScreen = gameScreen;
        pauseScreen.SetActive(false);
        currentState = State.GameScreen;
    }
}