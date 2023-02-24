using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionPolish : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private BallAudio ballAudio;
    private ImpactLevel ballImpact;

    private BallLocation ballLocation;
    //impacts are from the rigid body velocity magnitudes 
//Level 1 impact 0 - 1250
//level 2 impact 1250 - 2500
//level 3 impact 2500 or more




    private void Start()
    {
        particles.Stop();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
       
        if (col.gameObject.CompareTag("BoardBoundary"))
        {
           

            particles.Emit(50);
            var rb = GetComponent<Rigidbody2D>();
            
           DetermineBallImpact(rb.velocity.magnitude);
           DetermineLocation();

           ballAudio.PlayBallCollisionSfx(ballImpact, ballLocation);
        }
    }

    private void DetermineBallImpact(float vel)
    {
        if (vel < 1250)
        {
            ballImpact = ImpactLevel.LEVEL1;
        }
        else if (vel < 2500)
        {
            ballImpact = ImpactLevel.LEVEL2;
        }
        else
        {
            ballImpact = ImpactLevel.LEVEL3;
        }
    }

    /// <summary>
    /// if the ball is in the right left or middle during the collisoin.
    /// currentley the board is in the middle and the lenft of the board si from -420 to 420
    /// we can divide that in 3 seperate sectons and that will give the location
    /// (-420, -140, 140, +280  )
    /// </summary>
    private void DetermineLocation()
    {
        float xPos = transform.position.x;

        if (xPos > 140f)
        {
            ballLocation = BallLocation.RIGHT;
        }
        else if (xPos < -140f)
        {
            ballLocation = BallLocation.LEFT;
        }
        else
        {
            ballLocation = BallLocation.MID;
        }
    }
}

public enum ImpactLevel
{
    NONE, 
    LEVEL1, 
    LEVEL2,
    LEVEL3
}

public enum BallLocation
{
    NONE, 
    RIGHT, 
    LEFT,
    MID
}
