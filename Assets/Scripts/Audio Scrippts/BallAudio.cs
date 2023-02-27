using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallAudio : MonoBehaviour
{
    [SerializeField] private AudioSource collisionAudioSource;
    [SerializeField] private AudioSource ballHitSource;
    [SerializeField] private AudioClip ballCollisionSfx;
    [SerializeField] private AudioClip ballHitSfx;
    [SerializeField] private AudioClip ballCollisionObstacleSfx;
    private float obstacleSoundDelayTimer = 0;
    //this is to have a buffer time so you dont get that machine gun effect when the ball hits an obstacle reapetedly
    private const float obstacleSoundDelay = 0.5f;
    private bool ableToPlaySfx = true;
    private void Awake()
    {
        if (!collisionAudioSource)
        {
            Debug.Log("Audio source doesnt have a reference");
        }
            
    }


    private void Update()
    {
        obstacleSoundDelayTimer += Time.deltaTime;

        if (obstacleSoundDelayTimer > obstacleSoundDelay)
        {
            ableToPlaySfx = true;
            obstacleSoundDelayTimer = 0;
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
        RandomizeAudio();
        ballHitSource.PlayOneShot(ballHitSfx);
    }

    public void PlayBallCollisionSfx(ImpactLevel impactLevel, BallLocation ballLocation, bool isObstacle)
    {
        collisionAudioSource.pitch = 1f;
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
        if(!isObstacle)
            collisionAudioSource.PlayOneShot(ballCollisionSfx);
        else
        {
            if (ableToPlaySfx)
            {
                collisionAudioSource.PlayOneShot(ballCollisionObstacleSfx);
                ableToPlaySfx = false;
                obstacleSoundDelayTimer = 0;
            }

        }
    }
    
    private void RandomizeAudio()
    {
        collisionAudioSource.volume = Random.Range(0.75f, 1.0f);
        collisionAudioSource.pitch = Random.Range(0.9f, 1.1f);
    }
}
