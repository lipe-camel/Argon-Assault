using System;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    //STATS
    int currentScore;

    private void Start()
    {
        currentScore = 0;
        UpdateScore();
    }

    private void UpdateScore()
    {
        Debug.Log(currentScore);
    }

    public void AddToScore(int score)
    {
        currentScore += score;
        UpdateScore();
    }

    public void SubtractToScore(int score)
    {
        currentScore -= score;
        UpdateScore();
    }
}