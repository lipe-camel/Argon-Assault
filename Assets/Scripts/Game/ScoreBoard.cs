using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    //STATS
    int currentScore;

    //CACHED EXTERNAL REFERENCES
    [SerializeField] ScoreDisplay scoreDisplay;

    private void Start()
    {
        scoreDisplay.CustomStart();

        currentScore = 0;
        scoreDisplay.UpdateScore(currentScore);
    }


    public void AddToScore(int score)
    {
        currentScore += score;
        scoreDisplay.UpdateScore(currentScore);
    }

    public void SubtractToScore(int score)
    {
        currentScore -= score;
        scoreDisplay.UpdateScore(currentScore);
    }
}