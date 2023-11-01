using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private float elapsedTime;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject PanelTime;
    [SerializeField] private GameObject PanelWin;
    [SerializeField] private GameObject Controllers;


    public void Start()
    {
        Time.timeScale = 1f;
    }
    void Update()
    {

        //EL CONTADOR DE TIEMPO
        elapsedTime -= Time.deltaTime;
        int minutes = (int)((elapsedTime) / 60) % 60;
        int seconds = (int)((elapsedTime) % 60);
        string gameTimerString = string.Format("{0:0}:{1:00}", minutes, seconds);
        
        if (elapsedTime <= 0f)
        {
            //timerText.text = " SIN TIEMPO ";
            Time.timeScale = 0f;
            PanelTime.SetActive(true);
        }
        else
        {
            timerText.text = " " + gameTimerString + " " ; 
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        { 
            PanelWin.SetActive(true);
            Controllers.SetActive(false);
            Time.timeScale = 0f;
        }
        
    }
}
