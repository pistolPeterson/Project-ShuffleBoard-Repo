using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameplayUIAudio : MonoBehaviour
{
   [SerializeField] private AudioSource source;
   [SerializeField] private AudioClip positiveScoreSfx;
   [SerializeField] private AudioClip negativeScoreSfx;
   [SerializeField] private AudioClip gameOverAlarm;
   [SerializeField] private AudioClip warningSFX;
   [SerializeField] private AudioClip rdySetGoSFX;
   private GameManager gameManager; 

   private void Awake()
   {
      gameManager = FindObjectOfType<GameManager>();
      gameManager.OnGameOver.AddListener(PlayGameOverAlarmSfx);
      Debug.Log("Btw there is a reset scene if press r  and t ");
     
   }

   private void Start()
   {
      source.PlayOneShot(rdySetGoSFX);   
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

   public void PlayWarningSound()
   {
      source.volume = 0.5f;
      source.PlayOneShot(warningSFX);
      StartCoroutine(waitThenPutVolUp());
   }

   private IEnumerator waitThenPutVolUp()
   {
      yield return new WaitForSeconds(1.5f);
source.volume = 1.0f;
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
   
   private void RandomizeAudio()
   {
      source.volume = Random.Range(0.75f, 1.0f);
      source.pitch = Random.Range(0.9f, 1.1f);
   }
}
