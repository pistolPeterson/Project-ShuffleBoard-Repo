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

    [SerializeField] private Transform scoreColMidPoint;
    //public static event Action<int> OnBallCollide;


    private void Start()
    {
        if (scoreColMidPoint == null)
        {
            Debug.Log("there is not a midpoint gameobject as a child of this object");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.gameObject.CompareTag("Ball")) return;
        BallValue ballValue = col.gameObject.GetComponent<BallValue>();
       
        ballValue.scoreColliders.Add(this);
      

    }

    private void OnTriggerExit2D(Collider2D col)
    { 
        if(!col.gameObject.CompareTag("Ball")) return;
        BallValue ballValue = col.gameObject.GetComponent<BallValue>();

        if (ballValue.scoreColliders.Count > 0)
        {
            ballValue.scoreColliders.RemoveAt(0);
        }

    }

    public int GetScoreColliderValue()
    {
        return scoreAmount;
    }

    public Vector3 GetMidPointWorldPos()
    {
        return scoreColMidPoint.position;
    }
}
