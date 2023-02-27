using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaeusBombAudio : MonoBehaviour
{
  
   [SerializeField] private AudioSource source;
   [SerializeField] private AudioClip raeusWarningSfx;
   [SerializeField] private AudioClip raeusEXPLODESsfx;


   public void PlayExplosion()
   {
      RandomizeAudio();
      source.PlayOneShot(raeusEXPLODESsfx);
   }
   
   public void PlayWarningSound()
   {
      RandomizeAudio();
      source.PlayOneShot(raeusWarningSfx);
   }

   private void RandomizeAudio()
   {
      source.volume = Random.Range(0.75f, 1.0f);
      source.pitch = Random.Range(0.9f, 1.1f);
   }
}
