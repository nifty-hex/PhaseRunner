using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTutoriual : MonoBehaviour
{
    private TutorialSceneController controller;

    private void Start()
    {
        controller = GameObject.Find("TutorialSceneController").GetComponent<TutorialSceneController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "TutorialTrigger")
        {
            controller.tutorialTrigger();
            
        }
    }
}
