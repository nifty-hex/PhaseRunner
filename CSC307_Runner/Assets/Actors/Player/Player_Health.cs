using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player_Health : MonoBehaviour {

    public int health;
    public I_Frames i_frame;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (i_frame.invin == false)
        {
            if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Enemy_Bullet" || collision.gameObject.tag == "Obstacles")
            {
                health--;
                i_frame.invin = true;
                Debug.Log("Ouch");
            }
        }
        if (collision.gameObject.tag == "Enemy_Bullet")
        {
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (i_frame.invin == false)
        {
            if (collision.gameObject.tag == "Enemy_Bullet")
            {
                health--;
                i_frame.invin = true;
                Debug.Log("Ouch");
            }
        }
    }
}
