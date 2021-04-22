using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ScoreBoard : MonoBehaviour
{
    //STATS
    int currentScore;

    //CACHED COMPONENT REFERENCES
    AudioSource milestoneSFX;

    //CACHED EXTERNAL REFERENCES
    [SerializeField] ScoreDisplay scoreDisplay, finalScoreDisplay;

    private void Start()
    {
        scoreDisplay.CustomStart();
        milestoneSFX = GetComponent<AudioSource>();
        ResetScore();
    }


    public void AddToScore(int score)
    {
        currentScore += score;
        if (scoreDisplay)
        {
            scoreDisplay.UpdateScore(currentScore);
            if(currentScore >= 1000)
            {
                milestoneSFX.Play();
                StartCoroutine(scoreDisplay.TwinkleScore());
            }
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