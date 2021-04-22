using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] Color32 c1, c2, c3, c4;
    [SerializeField] float frameRate = 12f;
    [SerializeField] int numberOfFlashes= 4;

    //STATE
    Color32 defaultColor;

    //CACHED INTERNAL REFERENCES
    Text ScoreText;

    public void CustomStart()
    {
        ScoreText = GetComponent<Text>();
        defaultColor = ScoreText.color;
    }

    public void UpdateScore(int score)
    {
        GetComponent<Text>().text = score.ToString();
    }

    public IEnumerator TwinkleScore()
    {
        for (int i = 0; i < numberOfFlashes; i++)
        {
            ScoreText.color = c1;
            yield return new WaitForSeconds(1 / frameRate);
            ScoreText.color = c2;
            yield return new WaitForSeconds(1 / frameRate);
            ScoreText.color = c3;
            yield return new WaitForSeconds(1 / frameRate);
            ScoreText.color = c4;
            yield return new WaitForSeconds(1 / frameRate);

        }
        ScoreText.color = defaultColor;
    }
}