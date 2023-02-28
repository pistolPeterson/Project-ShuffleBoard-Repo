using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPanelAudio : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip selectBallSfx;
    [SerializeField] private AudioClip selectLevelSfx;
    public void PlaySelectBAllSfx()
    {
        source.volume = 1.0f;
        source.PlayOneShot(selectBallSfx);
    }

    
    public void PlaySelectLevelsfx()
    {
       
    }
}
