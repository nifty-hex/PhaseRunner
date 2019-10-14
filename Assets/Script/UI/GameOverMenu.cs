using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverMenu : MonoBehaviour
{
    private AudioManager audiomanager;
    public Transform highscore;
    public Transform score;
    public Transform stoppoint;
    private void Start()
    {
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        highscore = GameObject.Find("HighScore_text").GetComponent<RectTransform>();
        score = GameObject.Find("Score_text").GetComponent<RectTransform>();
        stoppoint = GameObject.Find("StopPoint").GetComponent<Transform>();
    }
    public void Update()
    {
        Time.timeScale = 1;
        if (highscore.position.x < stoppoint.position.x)
        {
            highscore.Translate(10 * Time.deltaTime, 0, 0);
        }
        else if (score.position.x < highscore.position.x)
        {
            score.Translate(10 * Time.deltaTime, 0, 0);
        }
    }

    public void Project()
    {
        audiomanager.Play("MouseClick");
        SceneManager.LoadScene("Project");
    }

    public void Menu()
    {
        audiomanager.Play("MouseClick");
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        audiomanager.Play("MouseClick");
        Application.Quit();
    }

    public void OnMouseOverButton()
    {
        audiomanager.Play("MouseOverButton");
    }
}
