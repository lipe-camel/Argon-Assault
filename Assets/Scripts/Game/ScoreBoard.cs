using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] ScoreDisplay scoreDisplay, finalScoreDisplay;
    [SerializeField] int initialMilestone = 1000;
    [SerializeField] int milestoneFactor = 2;

    //STATS
    int currentScore;
    int currentScoreMilestone;

    //CACHED COMPONENT REFERENCES
    AudioSource milestoneSFX;
        

    private void Start()
    {
        scoreDisplay.CustomStart();
        milestoneSFX = GetComponent<AudioSource>();
        currentScoreMilestone = initialMilestone;
        ResetScore();
    }


    public void AddToScore(int score)
    {
        currentScore += score;
        if (scoreDisplay)
        {
            scoreDisplay.UpdateScore(currentScore);
            CheckIfMilestone();
        }
    }

    private void CheckIfMilestone()
    {
        if (currentScore >= currentScoreMilestone)
        {
            milestoneSFX.Play();
            StartCoroutine(scoreDisplay.TwinkleScore());
            currentScoreMilestone *= milestoneFactor;
        }
    }

    public void ShowFinalScore()
    {
        finalScoreDisplay.UpdateScore(currentScore);
    }

    public void ResetScore()
    {
        currentScore = 0;
        if (scoreDisplay)
        {
            scoreDisplay.UpdateScore(currentScore);
        }
    }
}