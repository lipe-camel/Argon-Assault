using System.Collections;
using UnityEngine;


[RequireComponent(typeof(MenuInputs))]
public class GameState : MonoBehaviour
{
    //CONFIG PARAMS
    [Header("Screens")]
    [SerializeField] GameObject[] gameElements;
    [SerializeField] internal GameObject splashScreen, titleScreen, tutorialScreen, endScreen, creditsScreen;
    [Header("Time")]
    [SerializeField] float splashScreenTime = 2f;
    [SerializeField] float deathTime = 2f;
    [SerializeField] float clearScreenTime = 0.25f;
    [Header("Audio")]
    [SerializeField] internal AudioClip splashSFX;
    [SerializeField] internal AudioClip clickSFX;
    [SerializeField] internal AudioClip titleSFX;
    [SerializeField] internal AudioClip startSFX;
    [SerializeField] float SFXVolume = 0.4f;

    //STATE
    internal enum State { SplashScreen, TitleScreen, TutorialScreen, GameScreen, EndScreen, CreditsScreen};
    internal State currentState;
    internal GameObject currentScreen;

    //CACHED INTERNAL REFERENCES
    internal MenuInputs menuInputs;


    //START
    private void Start()
    {
        ManageInternalClasses();
        DeactivateAllScreens();
        StartCoroutine(ShowSplashScreen());
    }

    private void ManageInternalClasses()
    {
        menuInputs = GetComponent<MenuInputs>();
        menuInputs.CustomStart();
    }

    private void DeactivateAllScreens()
    {
        splashScreen.SetActive(false);
        titleScreen.SetActive(false);
        tutorialScreen.SetActive(false);
        endScreen.SetActive(false);
        creditsScreen.SetActive(false);
        foreach (GameObject gameElement in gameElements)
        {
            gameElement.SetActive(false);
        }
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
    internal IEnumerator ShowScreen(State state, GameObject screen)
    {
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

        yield return new WaitForSeconds(splashScreenTime /8);
        AudioSource.PlayClipAtPoint(splashSFX, Camera.main.transform.position, SFXVolume);

        yield return new WaitForSeconds(splashScreenTime * 7/8);

        StartCoroutine(ShowScreen(State.TitleScreen, titleScreen, titleSFX));
    }

    internal IEnumerator StartGame()
    {
        AudioSource.PlayClipAtPoint(startSFX, Camera.main.transform.position, SFXVolume);
        
        currentScreen.SetActive(false);
        yield return new WaitForSeconds(clearScreenTime);
        currentState = State.GameScreen;
        foreach (GameObject gameElement in gameElements)
        {
            gameElement.SetActive(true);
        }
    }

    public IEnumerator ShowEndScreen()
    {
        yield return new WaitForSeconds(deathTime);

        foreach (GameObject gameElement in gameElements)
        {
            gameElement.SetActive(false);
        }
        currentState = State.EndScreen;
        currentScreen = endScreen;
        endScreen.SetActive(true);
    }
}