using UnityEngine;

public class GlobalEffects: MonoBehaviour
{

    private void Awake()
    {
        int gameObjectCount = FindObjectsOfType<GlobalEffects>().Length;
        if (gameObjectCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
