using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTutorial : MonoBehaviour
{
    private TutorialSceneController controller;
    public GameObject explosion;

    private void Start()
    {
        controller = GameObject.Find("TutorialSceneController").GetComponent<TutorialSceneController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player_Bullet")
        {
            controller.destroyDummy();
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
