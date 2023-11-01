using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SendToAudioManager : MonoBehaviour
{
   
   private int _sceneNumber;
   private void Start()
   {
      _sceneNumber = SceneManager.GetActiveScene().buildIndex;
      Debug.Log(_sceneNumber);
      if ((_sceneNumber >= 0) && (_sceneNumber <= 1))
      {
         AudioManager.instance.Stop("Worlds");
         AudioManager.instance.Play("Intro");
      }
      
      if (_sceneNumber == 2)
      {
         AudioManager.instance.Stop("Dungeon");
         AudioManager.instance.Stop("Intro");
         AudioManager.instance.Stop("Levels");
         AudioManager.instance.Play("Worlds");
      }
      
      if (_sceneNumber >= 3)
      {
         AudioManager.instance.Stop("Dungeon");
         AudioManager.instance.Stop("Worlds");
         AudioManager.instance.Stop("Intro");
         AudioManager.instance.Play("Levels");
      }
     
   }

   public void LoadSound(string soundName)
   {
      AudioManager.instance.Play(soundName);
   }
   
   public void StopAudio(string soundName)
   {
      AudioManager.instance.Stop(soundName);
   }
}
