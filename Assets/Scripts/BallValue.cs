using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallValue : MonoBehaviour
{
    [SerializeField] private int ballValue = 0;

    public int GetBallValue()
    {
        return ballValue;
    }

    public void SetBallValue(int newValue)
    {
       // Debug.Log("changing the ball value " + newValue);
        ballValue = newValue;
    }
}
