using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

/// <summary>
/// summary?
/// </summary>
public class ScoreSystem : MonoBehaviour
{
    //TODO Raeus mf
    //add a mf summary 
    
    private int currentScore = 0;
    [SerializeField] private TMP_Text scoreText;
    
    //new way of updating score as per Raeus request in all her infinite game design knowledge 
    //score will only update when balls arent moving
    public void UpdateScore()
    {
        //currently a hacky way to do it, will refactor to improve a more optimized way 
        BallValue[] ballsInScene = FindObjectsOfType<BallValue>();
        int updatedScore = 0;

        foreach (var ball in ballsInScene)
        {
            ball.DetermineScore();
            updatedScore += ball.GetBallValue();
        }
        
        scoreText.text = "Score: " + updatedScore;
        currentScore = updatedScore;
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }
}
