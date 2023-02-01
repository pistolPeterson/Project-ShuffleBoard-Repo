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

    public static event Action<int> OnBallCollide;
  
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.gameObject.CompareTag("Ball")) return;
        OnBallCollide?.Invoke(scoreAmount);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(!col.gameObject.CompareTag("Ball")) return;
        OnBallCollide?.Invoke(-scoreAmount);
    }
}
