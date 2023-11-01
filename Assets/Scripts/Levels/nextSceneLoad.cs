using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextSceneLoad : MonoBehaviour
{
    public int _nextSceneLoad;

    private void Start()
    {
        _nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                //LEVEL DESBLOQUEADO AL MAXIMO
            }
            else
            {
                SceneManager.LoadScene(_nextSceneLoad);

                if (_nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                {
                    PlayerPrefs.SetInt("levelAt", _nextSceneLoad);
                }
            
            }
        }
    }
}
