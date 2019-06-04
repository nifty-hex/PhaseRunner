using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialSceneController : MonoBehaviour
{
    public Text text;
    public GameObject image;
    private GameObject trigger;
    public Transform Background1;
    public Transform Background2;
    public Transform Cam;
    public float currentPosition = 17.92f;
    public float width = 17.92f;
    private bool whichOne = true;
    float[] triggerLocation = new float[10];
    string[] tutorial = new string[10];
    int currentLocationIndex = 0;

    public GameObject button_A;
    public GameObject button_D;
    public GameObject button_1;
    public GameObject button_2;
    public GameObject button_3;
    public GameObject button_4;
    public GameObject button_left;
    public GameObject button_space;
    public GameObject button_mouse;
    public GameObject button_shift;

    void Start()
    {
        trigger = GameObject.Find("TutorialTrigger");
        image.SetActive(false);
        triggerLocation[0] = 2.7f;
        triggerLocation[1] = 9.9f;
        triggerLocation[2] = 20.7f;
        triggerLocation[3] = 36f;
        triggerLocation[4] = 67f;
        triggerLocation[5] = 88.9f;
        tutorial[0] = " Hello there, you are in a\n simulated training room.\n We will start preparing\n you for your run.";
        tutorial[1] = "     CONTROL\n\n     Aim:\n\n     Shoot:\n\n     Jump:";
        tutorial[2] = "     CONTROL\n\n     Speed up:\n\n     Slow down:\n\n     Slow time:";
        tutorial[3] = "     GUNS\n\n     Pistol:\n\n     Machine gun:\n\n     Shotgun:\n\n     Railgun:";
        tutorial[4] = " Now destroy the drone in \nfront of you ane we can\n proceed to the run.";
        tutorial[5] = " Oops! You missed your chance to destroy the drone. Restarting the training course shortly.";
        trigger.transform.position = new Vector3(triggerLocation[currentLocationIndex], -1.08f, 0);
    }

    void Update()
    {
        if (Cam.position.x > currentPosition)
        {
            if (whichOne)
            {
                Background1.localPosition = new Vector2(Background1.localPosition.x + 2 * width, 0f);

            }
            else
            {
                Background2.localPosition = new Vector2(Background2.localPosition.x + 2 * width, 0f);

            }
            currentPosition += width;
            whichOne = !whichOne;
        }
        else if (Cam.position.x < currentPosition - width)
        {

            if (whichOne)
            {
                Background2.localPosition = new Vector2(Background2.localPosition.x - 2 * width, 0f);

            }
            else
            {
                Background1.localPosition = new Vector2(Background1.localPosition.x - 2 * width, 0.5f);

            }
            currentPosition -= width;
            whichOne = !whichOne;
        }
    }

    public void destroyDummy()
    {
        StartCoroutine(changeScene());
    }

    public void tutorialTrigger()
    {
        text.text = tutorial[currentLocationIndex];
        if (currentLocationIndex == 1)
        {
            button_mouse.SetActive(true);
            button_left.SetActive(true);
            button_space.SetActive(true);
        }
        else if (currentLocationIndex == 2)
        {
            button_D.SetActive(true);
            button_A.SetActive(true);
            button_shift.SetActive(true);
        }
        else if (currentLocationIndex == 3)
        {
            button_1.SetActive(true);
            button_2.SetActive(true);
            button_3.SetActive(true);
            button_4.SetActive(true);
        }
        image.SetActive(true);
        StartCoroutine(disableText());
        currentLocationIndex++;
    }

    IEnumerator disableText()
    {
        yield return new WaitForSeconds(5);
        if (currentLocationIndex == 2)
        {
            button_mouse.SetActive(false);
            button_left.SetActive(false);
            button_space.SetActive(false);
        }
        else if (currentLocationIndex == 3)
        {
            button_D.SetActive(false);
            button_A.SetActive(false);
            button_shift.SetActive(false);
        }
        else if (currentLocationIndex == 4)
        {
            button_1.SetActive(false);
            button_2.SetActive(false);
            button_3.SetActive(false);
            button_4.SetActive(false);
        }
        else if (currentLocationIndex == 6)
        {
            StartCoroutine(restartScene());
        }
        image.SetActive(false);
        trigger.transform.position = new Vector3(triggerLocation[currentLocationIndex], -1.08f, 0);
    }

    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Project");
    }

    IEnumerator restartScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

