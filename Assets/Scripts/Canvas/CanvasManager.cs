using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Sprites;


public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject canvasPause;
    [SerializeField] private GameObject canvasController;
    [SerializeField] private GameObject pauseBoton;
   
    private Scene actual;
    private string nombreEscena;

    private void Start()
    {
        //Saber la scena actual
        actual = SceneManager.GetActiveScene();
        nombreEscena = actual.name;
    }
    public void Pause()
    {
        AudioManager.instance.Stop("Dungeon");
        AudioManager.instance.Stop("Levels");
        AudioManager.instance.Play("PauseMenu");

        pauseBoton.SetActive(false);
            Time.timeScale = 0f;
            player.GetComponent<playerMovement>().enabled = false;
            canvasController.SetActive(false);
            canvasPause.SetActive(true);
  
    }
    public void Resume()
    {
        AudioManager.instance.Stop("Dungeon");
        AudioManager.instance.Stop("PauseMenu");
        if (nombreEscena == "M1S6")
        {
            AudioManager.instance.Play("Dungeon");
        }
        else
        {
            AudioManager.instance.Play("Levels");
        }
        
        pauseBoton.SetActive(true);
        Time.timeScale = 1f;
        player.GetComponent<playerMovement>().enabled = true;
        canvasController.SetActive(true);
        canvasPause.SetActive(false);
    }
    
    public void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }
    
    public void Menu()
    {
        AudioManager.instance.Stop("Levels");
        AudioManager.instance.Stop("PauseMenu");
        AudioManager.instance.Stop("Dungeon");
        AudioManager.instance.Play("Worlds");
        
        SceneManager.LoadScene("SelectWorld");
    }
    public void QuitGame()
    {
        Debug.Log("Has Salido!!");
        Application.Quit();
    }
    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nombreEscena);
    }
    public void SelectLevel()
    {
        AudioManager.instance.Stop("Dungeon");
        AudioManager.instance.Stop("Levels");
        AudioManager.instance.Stop("PauseMenu");
        AudioManager.instance.Play("Worlds");
        
        SceneManager.LoadScene("SelectWorld");
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(nombreEscena + 1);
    }

    private void OnEnable()
    {
        InputManager.Pause += Pause;
    }

    private void OnDisable()
    {
        InputManager.Pause -= Pause;
    }
}
