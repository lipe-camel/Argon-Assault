using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float splashScreenTime = 2f;
    [SerializeField] float deathRestart = 2f;

    int currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene == 0)
        {
            Invoke("LoadNextScene", splashScreenTime);
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentScene + 1);
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void DeathRestart()
    {
        Invoke("RestartScene", deathRestart);
    }
}
