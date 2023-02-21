using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAudio : MonoBehaviour
{
    [SerializeField] private AudioSource collisionAudioSource;
    [SerializeField] private AudioSource ballHitSource;
    [SerializeField] private AudioClip ballCollisionSfx;
    [SerializeField] private AudioClip ballHitSfx;


    private void Awake()
    {
        if (!collisionAudioSource)
        {
            Debug.Log("Audio source doesnt have a reference");
        }
            
    }


    public void PlayBallHitSfx(float ballLinePower)
    {
        if (ballLinePower < 1200)
        {
            ballHitSource.volume = 0.2f; 
        } 
        else if (ballLinePower < 2400)
        {
            ballHitSource.volume = 0.4f; 
        }
        else if (ballLinePower < 3600)
        {
            ballHitSource.volume = 0.6f; 
        }
        else if (ballLinePower < 4800)
        {
            ballHitSource.volume = 0.8f; 
        }
        else
        {
            ballHitSource.volume = 1f; 

        }
        ballHitSource.PlayOneShot(ballHitSfx);
    }

    public void PlayBallCollisionSfx(ImpactLevel impactLevel, BallLocation ballLocation)
    {
        //how loud to play
        switch (impactLevel)
        {
            case ImpactLevel.LEVEL1:
                collisionAudioSource.volume = 0.25f;
                break;
            case ImpactLevel.LEVEL2:
                collisionAudioSource.volume = 0.50f;
                break;
            case ImpactLevel.LEVEL3:
                collisionAudioSource.volume = 1.0f;
                break;
        }
        //which panning area to play 
        switch (ballLocation)
        {
            case BallLocation.MID:
                collisionAudioSource.panStereo  = 0;
                break;
            
            case BallLocation.LEFT:
                collisionAudioSource.panStereo  = -0.5f;
                break;
            case BallLocation.RIGHT:
                collisionAudioSource.panStereo  = 0.5f;
                break;
            
           
        }
        collisionAudioSource.PlayOneShot(ballCollisionSfx);
    }
}
