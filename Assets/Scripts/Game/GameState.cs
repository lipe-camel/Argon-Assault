using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] GameObject splashScreen, titleScreen, tutorialScreen, endScreen;
    [SerializeField] GameObject[] gameElements;
    [SerializeField] float
        splashScreenTime = 2f,
        clearScreenTime = 0.5f;


    //STATE
    enum Screen { SplashScreen, TitleScreen, TutorialScreen, GameScreen, EndScreen};
    Screen currentScreen;


    private void Start()
    {
        splashScreen.SetActive(false);
        titleScreen.SetActive(false);
        tutorialScreen.SetActive(false);
        endScreen.SetActive(false);
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
    }

    private IEnumerator ManageSplashScreen()
    {
        currentScreen = Screen.SplashScreen;
        splashScreen.SetActive(true);
        Debug.Log(currentScreen);
        yield return new WaitForSeconds(splashScreenTime);
        splashScreen.SetActive(false);
        yield return new WaitForSeconds(clearScreenTime);
        ManageTitleScreen();
    }

    private void ManageTitleScreen()
    {
        currentScreen = Screen.TitleScreen;
        Debug.Log(currentScreen);
        titleScreen.SetActive(true);
    }

    private IEnumerator ManageTutorialScreen()
    {
        titleScreen.SetActive(false);
        yield return new WaitForSeconds(clearScreenTime);
        currentScreen = Screen.TutorialScreen;
        Debug.Log(currentScreen);
        tutorialScreen.SetActive(true);
    }

    private IEnumerator ManageGameScreen()
    {
        tutorialScreen.SetActive(false);
        yield return new WaitForSeconds(clearScreenTime);
        currentScreen = Screen.GameScreen;
        Debug.Log(currentScreen);
        foreach (GameObject gameElement in gameElements)
        {
            gameElement.SetActive(true);
        }
    }
}
