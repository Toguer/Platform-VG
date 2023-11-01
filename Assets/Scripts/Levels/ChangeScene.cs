using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void nextScene()
    {
        int scene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(scene);
    }

    public void backScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
