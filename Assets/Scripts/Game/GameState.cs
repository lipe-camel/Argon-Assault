using System.Collections;
using UnityEngine;

public class GameState : MonoBehaviour
{
    //CONFIG PARAMS
    [Header("Screens")]
    [SerializeField] GameObject[] gameElements;
    [SerializeField] GameObject splashScreen, titleScreen, tutorialScreen, endScreen, creditsScreen;
    [Header("Time")]
    [SerializeField] float splashScreenTime = 2f;
    [SerializeField] float clearScreenTime = 0.25f;
    [Header("Audio")]
    [SerializeField] AudioClip splashSFX;
    [SerializeField] AudioClip clickSFX;
    [SerializeField] AudioClip titleSFX;
    [SerializeField] AudioClip startSFX;
    [SerializeField] float SFXVolume = 0.4f;

    //STATE
    enum Screen { SplashScreen, TitleScreen, TutorialScreen, GameScreen, EndScreen, CreditsScreen};
    Screen currentScreen;


    private void Start()
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

        StartCoroutine(ManageSplashScreen());
    }

    private void Update()
    {
        if(currentScreen == Screen.TitleScreen)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(ManageTutorialScreen());
            }
        }

        if (currentScreen == Screen.TutorialScreen)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(ManageGameScreen());
            }
        }

        if (currentScreen == Screen.EndScreen)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(ManageGameScreen());
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                StartCoroutine(ManageCreditsScreen());
            }
        }

        if(currentScreen == Screen.CreditsScreen)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(ManageGameScreen());
            }
        }
    }

    private IEnumerator ManageSplashScreen()
    {
        currentScreen = Screen.SplashScreen;
        splashScreen.SetActive(true);
        Debug.Log(currentScreen);
        yield return new WaitForSeconds(splashScreenTime /8);
        AudioSource.PlayClipAtPoint(splashSFX, Camera.main.transform.position, SFXVolume);
        yield return new WaitForSeconds(splashScreenTime * 7/8);
        splashScreen.SetActive(false);
        yield return new WaitForSeconds(clearScreenTime);
        ManageTitleScreen();
    }

    private void ManageTitleScreen()
    {
        AudioSource.PlayClipAtPoint(titleSFX, Camera.main.transform.position, SFXVolume);
        currentScreen = Screen.TitleScreen;
        Debug.Log(currentScreen);
        titleScreen.SetActive(true);
    }

    private IEnumerator ManageTutorialScreen()
    {
        titleScreen.SetActive(false);
        AudioSource.PlayClipAtPoint(clickSFX, Camera.main.transform.position, SFXVolume);
        yield return new WaitForSeconds(clearScreenTime);
        currentScreen = Screen.TutorialScreen;
        Debug.Log(currentScreen);
        tutorialScreen.SetActive(true);
    }

    private IEnumerator ManageGameScreen()
    {
        tutorialScreen.SetActive(false);
        endScreen.SetActive(false);
        creditsScreen.SetActive(false);
        AudioSource.PlayClipAtPoint(startSFX, Camera.main.transform.position, SFXVolume);
        yield return new WaitForSeconds(clearScreenTime);
        currentScreen = Screen.GameScreen;
        Debug.Log(currentScreen);
        foreach (GameObject gameElement in gameElements)
        {
            gameElement.SetActive(true);
        }
    }

    public IEnumerator ManageEndScreen()
    {
        yield return new WaitForSeconds(2f);
        foreach (GameObject gameElement in gameElements)
        {
            gameElement.SetActive(false);
        }
        currentScreen = Screen.EndScreen;
        endScreen.SetActive(true);
    }

    private IEnumerator ManageCreditsScreen()
    {
        endScreen.SetActive(false);
        yield return new WaitForSeconds(clearScreenTime);
        currentScreen = Screen.CreditsScreen;
        creditsScreen.SetActive(true);
    }
}