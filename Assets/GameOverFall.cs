using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GameOverFall: MonoBehaviour{
    [SerializeField] private GameObject PanelTime;
    [SerializeField] private GameObject Controllers;
    public static GameOverFall _gameOverFall;


    private void Start()
    {
        _gameOverFall = this;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameOver();
        }
    }


    public  void GameOver()
    {
        PanelTime.SetActive(true);
        Controllers.SetActive(false);
        Time.timeScale = 0f;
    }
}