using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip uIAcceptSfx;
    [SerializeField] private AudioClip uIBackSfx;


    private void Awake()
    {
        if (audioSource == null)
        {
            Debug.Log("Audio source is not set in insepctor");
        }
    }

    public void PlayAcceptSfx()
    {
        audioSource.PlayOneShot(uIAcceptSfx);
    }

    
    public void PlayBackSfx()
    {
        audioSource.PlayOneShot(uIBackSfx);

    }

}
