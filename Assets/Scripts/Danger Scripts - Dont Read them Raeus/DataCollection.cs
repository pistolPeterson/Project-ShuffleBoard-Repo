using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

/// <summary>
/// simple script to know the average length it takes each time a new ball is spawned. to determine info for a new secret game
/// mechanic
/// this data collection is WITHOUT any permission from the end user, thats right, this game invades your privacy, too bad
/// </summary>
public class DataCollection : MonoBehaviour
{
   // private int amountOfTimesBallSpawned;
  //  private float totalTime;
    
    private const string AMOUNT_OF_BALLS_SPAWNED_KEY = "RaeusCantReadIn2023";
    private const string TOTAL_TIME_KEY = "IfRaeusReadsThisItWillBeAMiracle";

    private GameManager gameManager;
    private float timer = 0.0f;
    
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (!gameManager)
        {
            Debug.Log("There should be a gamemanager in this scene dummy");
        }

        gameManager.OnBallSpawn.AddListener(UpdateData);
        
        
        Init();
    }

    private void Init()
    {
        if (!PlayerPrefs.HasKey(AMOUNT_OF_BALLS_SPAWNED_KEY))
        {
            Debug.Log("initing for int");
            SetInt(AMOUNT_OF_BALLS_SPAWNED_KEY, 0);
        }

        if (!PlayerPrefs.HasKey(TOTAL_TIME_KEY))
        {
            Debug.Log("initing for float");

            SetFloat(TOTAL_TIME_KEY, 0.0f);
        }
      
    }

    private void Update()
    {
        if (gameManager.isGameStarted)
            timer += Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            GetCurrentData();
        }
    }

    private void UpdateData()
    {

        SetInt(AMOUNT_OF_BALLS_SPAWNED_KEY, GetInt(AMOUNT_OF_BALLS_SPAWNED_KEY) + 1);

        SetFloat(TOTAL_TIME_KEY, GetFloat(TOTAL_TIME_KEY) + timer);
        timer = 0.0f;

    }

   

    private void GetCurrentData()
    {
        string text = "";

        text += "The amount of Times of the ball was spawned: " + GetInt(AMOUNT_OF_BALLS_SPAWNED_KEY) + "\n";
        text += "The total time elapsed while game is playing: " + GetFloat(TOTAL_TIME_KEY) + "\n";
        text += "The average time elasped per ball spawned: " + GetFloat(TOTAL_TIME_KEY)/GetInt(AMOUNT_OF_BALLS_SPAWNED_KEY) +"\n";
        
        
        Debug.Log(text);
    }

    private void SetFloat(string key, float newFloat)
    {
        PlayerPrefs.SetFloat(key, newFloat);
    }
    
    private float GetFloat(string key)
    {
        if (!PlayerPrefs.HasKey(key))
            Debug.Log("yo this key doesnt exist.");
        
        return PlayerPrefs.GetFloat(key);
    }
    
    private void SetInt(string key, int newInt)
    {
        PlayerPrefs.SetInt(key, newInt);
    }
    
    private int GetInt(string key)
    {
        if (!PlayerPrefs.HasKey(key))
            Debug.Log("yo this key doesnt exist.");
        
        return PlayerPrefs.GetInt(key);
    }
}
