using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverMenu : MonoBehaviour
{
    public void Update()
    {
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("Project");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
