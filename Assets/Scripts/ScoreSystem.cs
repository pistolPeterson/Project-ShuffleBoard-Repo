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
    //remove the testing stuff 
    private int currentScore = 0;
    [SerializeField] private TMP_Text scoreText;
    

    private void OnEnable()
    {
        ScoreCollider.OnBallCollide += UpdateScore;
    }


    private void OnDisable()
    {
        ScoreCollider.OnBallCollide -= UpdateScore;
    }

   
    //original way of updating score 
    //anytime ball passed collider, the score would change 
    private void UpdateScore(int addedScore)
    {
        currentScore += addedScore;
        scoreText.text = "Score: " + currentScore;
    }

    //new way of updating score as per Raeus request in all her infinite game design knowledge 
    //score only updates when balls arent moving
    public void UpdateScore()
    {
        Debug.Log("doing new updated score");
        //currently a hacky way to do it, will refactor to improve a more optimize way 
        BallValue[] urMouth = FindObjectsOfType<BallValue>();

        int updatedScore = 0;

        foreach (var deezNuts in urMouth)
        {
            updatedScore += deezNuts.GetBallValue();
        }
        
        scoreText.text = "Score: " + updatedScore;
    }
}
