using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistics : MonoBehaviour
{
    //all data needed for "one" level:
    //  -how many times player completed a match 
    //  -highest score for the level 
    //  -total score from all games played for this level
    
    //stats that will be shown to the player: 
    //  -how many times they completed the level 
    //  -their highest score 
    //  -their average score 
    
    //to create a "key" for a player pref it will be a string key plus a number added to it, which is the level number
    
    private const string AMOUNT_PLAYED_KEY = "DeezNuts";
    private const string HIGH_SCORE_KEY = "SpaceGamesSuck";
    private const string TOTAL_SCORE_KEY = "SpaceGamesDeezNuts";
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (!gameManager)
        {
            Debug.Log("bruh why is there no game manager in this scene?");
        }
    }

    private void Start()
    {
        gameManager.OnGameOver.AddListener(Statistics_OnGameOver);
    }

    private int GetTotalScoreFromAllGamesPlayed(int levelNumber)
    {
        return PlayerPrefs.GetInt(TOTAL_SCORE_KEY + levelNumber);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            GetCurrentStats();
        }
        
        if (Input.GetKeyDown(KeyCode.D) && Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("reseting all scores for this level");
            ResetAllDataForThisLevel();
        }
    }

    private void GetCurrentStats()
    {
        string text = "";
        text += "Stats for level: " + gameManager.CurrentLevelNumber + "\n";
        text += "Amount of times completed Level: " + GetAmountOfGamesPlayedForLevel(gameManager.CurrentLevelNumber) + "\n";
        text += "The highest score for this level: " + GetHighestScoreForLevel(gameManager.CurrentLevelNumber) + "\n";
        text += "The average score for this level: " + GetAverageScoreForLevel(gameManager.CurrentLevelNumber) +"\n";
        
        
        Debug.Log(text);
    }

    private void Statistics_OnGameOver()
    {
        Debug.Log("doing stats stuff");
        //increase amount played 
        PlayerPrefs.SetInt(AMOUNT_PLAYED_KEY + gameManager.CurrentLevelNumber, GetAmountOfGamesPlayedForLevel(gameManager.CurrentLevelNumber)  + 1);
        
        //check if we should increase the high score 
        ScoreSystem ss = FindObjectOfType<ScoreSystem>();
        int currentScore = ss.GetCurrentScore();

        if (currentScore > GetHighestScoreForLevel(gameManager.CurrentLevelNumber))
        {
            PlayerPrefs.SetInt(HIGH_SCORE_KEY + gameManager.CurrentLevelNumber, currentScore);
        }


        //add score to the total score 
        PlayerPrefs.SetInt(TOTAL_SCORE_KEY + gameManager.CurrentLevelNumber, GetTotalScoreFromAllGamesPlayed(gameManager.CurrentLevelNumber) + currentScore);
        
    }

    public int GetAmountOfGamesPlayedForLevel(int levelNumber)
    {
        return PlayerPrefs.GetInt(AMOUNT_PLAYED_KEY + levelNumber);
    }

    public int GetHighestScoreForLevel(int levelNumber)
    {
        return PlayerPrefs.GetInt(HIGH_SCORE_KEY + levelNumber);
    }
    
    public int GetAverageScoreForLevel(int levelNumber)
    {
        //average score is all scores from the game played / the amount of times they played the game 
        //we will round to the lower int, basically integer division 
        int totalScore = GetTotalScoreFromAllGamesPlayed(levelNumber);
        int amountOfTimesPlayed = GetAmountOfGamesPlayedForLevel(levelNumber);
        
  
        //quick check if amount of times played is less than 1 
        if (amountOfTimesPlayed < 1)
        {
            Debug.Log("didnt even complete a game bruh");
            return 0;
        }
        int averageScore = totalScore / amountOfTimesPlayed;
       
        
        return averageScore;
    }

    private void ResetAllDataForThisLevel()
    {
        PlayerPrefs.SetInt(AMOUNT_PLAYED_KEY + gameManager.CurrentLevelNumber, 0);
        PlayerPrefs.SetInt(TOTAL_SCORE_KEY + gameManager.CurrentLevelNumber, 0);
        PlayerPrefs.SetInt( HIGH_SCORE_KEY + gameManager.CurrentLevelNumber, 0);
    }
    
}
