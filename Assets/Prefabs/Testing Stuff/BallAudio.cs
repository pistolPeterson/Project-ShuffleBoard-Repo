using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAudio : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip ballCollisionSfx;


    private void Awake()
    {
        if (!source)
        {
            Debug.Log("Audio source doesnt have a reference");
        }
            
    }


    public void PlayBallCollisionSfx(ImpactLevel impactLevel, BallLocation ballLocation)
    {
        //how loud to play
        switch (impactLevel)
        {
            case ImpactLevel.LEVEL1:
                source.volume = 0.25f;
                break;
            case ImpactLevel.LEVEL2:
                source.volume = 0.50f;
                break;
            case ImpactLevel.LEVEL3:
                source.volume = 1.0f;
                break;
        }
        //which panning area to play 
        switch (ballLocation)
        {
            case BallLocation.MID:
                source.panStereo  = 0;
                break;
            
            case BallLocation.LEFT:
                source.panStereo  = -0.5f;
                break;
            case BallLocation.RIGHT:
                source.panStereo  = 0.5f;
                break;
            
           
        }
        source.PlayOneShot(ballCollisionSfx);
    }
}
