using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
      Debug.Log("Btw there is a reset scene if press r  and t ");
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

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.R) && Input.GetKeyDown(KeyCode.T))
      {
         SceneManager.LoadScene(0);
      }
   }
}
