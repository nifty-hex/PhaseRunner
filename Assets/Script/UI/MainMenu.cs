using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioManager audiomanager;
    public Transform menuborder;
    public Transform settingsborder;
    public Transform stopPoint;
    public Transform stopPoint2;
    private bool showMenu = false;
    private bool showSettings = false;

    private void Start()
    {
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        audiomanager.PlayMenu();
        StartCoroutine(moveUpMenuBorder());
    }

    private void Update()
    {
        if(showMenu && menuborder.position.y < stopPoint.position.y)
        {
            menuborder.Translate(0, 15 * Time.deltaTime, 0);
        }
        else if(!showMenu && menuborder.position.y > stopPoint2.position.y)
        {
            menuborder.Translate(0, -15 * Time.deltaTime, 0);
        }

        if (showSettings && settingsborder.position.y < stopPoint.position.y)
        {
            settingsborder.Translate(0, 15 * Time.deltaTime, 0);
        }
        else if (!showSettings && settingsborder.position.y > stopPoint2.position.y)
        {
            settingsborder.Translate(0, -15 * Time.deltaTime, 0);
        }
    }

    public void PlayGame()
    {
        showMenu = false;
        audiomanager.Play("MouseClick");
        StartCoroutine(delayLoadScene("Project"));
    }

    public void QuitGame()
    {
        showMenu = false;
        audiomanager.Play("MouseClick");
        Application.Quit();
    }

    public void Tutorial()
    {
        showMenu = false;
        audiomanager.Play("MouseClick");
        StartCoroutine(delayLoadScene("Tutor(WIP)"));
    }

    public void Settings()
    {
        showMenu = false;
        audiomanager.Play("MouseClick");
        showSettings = true;
    }

    public void BackToMenu()
    {
        showMenu = true;
        audiomanager.Play("MouseClick");
        showSettings = false;
    }

    public void OnMouseOverButton()
    {
        audiomanager.Play("MouseOverButton");
    }

    IEnumerator moveUpMenuBorder()
    {
        yield return new WaitForSeconds(0.5f);
        showMenu = true;
    }

    IEnumerator delayLoadScene(string name)
    {
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene(name);
    }
}

