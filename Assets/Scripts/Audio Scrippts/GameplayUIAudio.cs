using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayUIAudio : MonoBehaviour
{
   [SerializeField] private AudioSource source;
   [SerializeField] private AudioClip positiveScoreSfx;
   [SerializeField] private AudioClip negativeScoreSfx;
   [SerializeField] private AudioClip gameOverAlarm;

   private GameManager gameManager; 

   private void Awake()
   {
      gameManager = FindObjectOfType<GameManager>();
      gameManager.OnGameOver.AddListener(PlayGameOverAlarmSfx);
   }

   public void PlayPosScoreSfx()
   {
      source.PlayOneShot(positiveScoreSfx);
   }
   
   public void PlayNegScoreSfx()
   {
      source.PlayOneShot(negativeScoreSfx);
   }

   private void PlayGameOverAlarmSfx()
   {
      source.PlayOneShot(gameOverAlarm);
   }

   public void PlayAudioBasedOnScore(int score)
   {
      if (score == 0)
      {
         //do nothing
      }
      else if (score > 0)
      {
         PlayPosScoreSfx();

      }
      else
      {
         PlayNegScoreSfx();
      }
   }
}
