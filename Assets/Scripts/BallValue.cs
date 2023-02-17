using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BallValue : MonoBehaviour
{
    [SerializeField] private int ballValue = 0;
    public List<ScoreCollider> scoreColliders;
    private ScoreCollider minScoreCollider;

    private ScoreSystem scoreSystem;

    private void Awake()
    {
        scoreSystem = FindObjectOfType<ScoreSystem>();
        if (!scoreSystem)
        {
            Debug.Log("there is no ScoreSystem script in the scene!");
        }
    }

    public int GetBallValue()
    {
        return ballValue;
    }

    private void SetBallValue(int newValue)
    {
        ballValue = newValue;
    }

    public void Init()
    {
        ClearScoreColliders();
        SetBallValue(0);
    }
    public void DetermineScore()
    {
        if (scoreColliders.Count <= 0)
        {
            //nothing in score collieders means it is not inside the scoring areas
            SetBallValue(0);
            return;
        }

        //as a default case, set it as the first element in the list
        float minDistance = Vector3.Distance(transform.position, scoreColliders[0].GetMidPointWorldPos());
        minScoreCollider = scoreColliders[0];
        
        //if there is elemennts in the list, go through all the elements in that list 
        //and set it to the one you are closest to
        foreach (ScoreCollider col in scoreColliders)
        {
           float tempDistance =  Vector3.Distance(transform.position, col.GetMidPointWorldPos());
           if (tempDistance < minDistance)
           {
               minScoreCollider = col;
           }
        }

        
        SetBallValue(minScoreCollider.GetScoreColliderValue());
        
    }

    public void CallUpdateScore()
    {
        scoreSystem.UpdateScore();
    }
        

    private void ClearScoreColliders()
    {
        scoreColliders = new List<ScoreCollider>();
    }
}
