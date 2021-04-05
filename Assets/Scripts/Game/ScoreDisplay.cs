using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    //CACHED INTERNAL REFERENCES
    Text ScoreText;

    private void Start()
    {
        ScoreText = GetComponent<Text>();
    }

    public void UpdateScore(int score)
    {
        ScoreText.text = score.ToString();
    }
}
