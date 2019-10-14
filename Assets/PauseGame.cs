using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public Transform stopPoint;
    public Transform stopPoint2;
    public Transform settingsborder;
    private AudioManager audiomanager;
    private bool paused = false;


    // Start is called before the first frame update
    void Start()
    {
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (paused && settingsborder.position.y < stopPoint.position.y)
        {
            settingsborder.Translate(0, 15 * 0.02f, 0);
        }
        else if (!paused && settingsborder.position.y > stopPoint2.position.y)
        {
            settingsborder.Translate(0, -15 * 0.02f, 0);
        }

    }

    public void BackToGame()
    {
        audiomanager.Play("MouseClick");
        paused = false;
        Time.timeScale = 1f;
    }

    public void PauseTheGame()
    {
        Time.timeScale = 0f;
        paused = true;
    }

    public bool isPaused()
    {
        return paused;
    }

    public void MouseOverButton()
    {
        audiomanager.Play("MouseOverButton");
    }
}
