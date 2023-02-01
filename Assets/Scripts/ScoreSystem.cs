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
    [SerializeField] private int pointsLowerLimit = -5;
    [SerializeField] private int pointsUpperLimit = 10;

    private void OnEnable()
    {
        ScoreCollider.OnBallCollide += UpdateScore;
    }


    private void OnDisable()
    {
        ScoreCollider.OnBallCollide -= UpdateScore;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
           int randomScore = Random.Range(pointsLowerLimit, pointsUpperLimit);
           UpdateScore(randomScore);   
        }     
    }

    private void UpdateScore(int addedScore)
    {
        currentScore += addedScore;
        scoreText.text = "Score: " + currentScore;
    }
}
