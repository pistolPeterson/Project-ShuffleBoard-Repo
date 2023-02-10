using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The collision system, that will update the score when the balls pass through it using events
/// </summary>
public class ScoreCollider : MonoBehaviour
{
    [SerializeField] private int scoreAmount = 10;

    //public static event Action<int> OnBallCollide;
  
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.gameObject.CompareTag("Ball")) return;
        BallValue ballValue = col.gameObject.GetComponent<BallValue>();
        if(ballValue)
            ballValue.SetBallValue(scoreAmount);


    }

    private void OnTriggerStay2D(Collider2D col)
    {
        
        
        if(!col.gameObject.CompareTag("Ball")) return;
        BallValue ballValue = col.gameObject.GetComponent<BallValue>();
        
        if (IsInside(GetComponent<Collider2D>(), col.gameObject.transform.position))
        {
            
        }
        else
        {
        //    Debug.Log("mf ball isnt inside");
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(!col.gameObject.CompareTag("Ball")) return;
       // OnBallCollide?.Invoke(-scoreAmount);
       BallValue ballValue = col.gameObject.GetComponent<BallValue>();
       if(ballValue)
           ballValue.SetBallValue(0);
    }
    public static bool IsInside(Collider2D c, Vector3 point)
    {
        Vector3 closest = c.ClosestPoint(point);
        // Because closest=point if point is inside - not clear from docs I feel
        return closest == point;
    }
    
}
