using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Player_Health : MonoBehaviour {

    public int health;
    public I_Frames i_frame;

    public float time_slowness = 0.5f;
    public float time_fix_mul;

    public GameObject bg;
    public float change_speed;
    public float bg_y_offset;
    Color tmp;
    public bool die = false;

    public float time_till_scene_change = 3f;
    public Player_Score scoreObject;
    private AudioManager audiomanager;

    private void Start()
    {
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    void Update () {
		if (health <= 0)
        {
            bg.GetComponent<SpriteRenderer>().sortingOrder = 10;
            if (Time.timeScale > time_slowness)
            {
                Time.timeScale -= (Time.deltaTime * time_fix_mul);
            }

            tmp = bg.GetComponent<SpriteRenderer>().color;

            if (die == false)
            {
                audiomanager.Play("Player_Die");
                tmp = Color.red;
                tmp.a = 0;
                die = true;
            }
            
            if (tmp.a < 1f)
            {
                tmp.a += change_speed;
            }
            bg.GetComponent<SpriteRenderer>().color = tmp;

            if (tmp.a >= 1f)
            {
                if (time_till_scene_change > 0)
                {
                    time_till_scene_change -= Time.deltaTime;
                }
                else
                {
                    audiomanager.StopAll();
                    PlayerPrefs.SetInt("CurrentScore", scoreObject.getScore());
                    if (scoreObject.getScore() > PlayerPrefs.GetInt("HighScore", 0))
                    {
                        PlayerPrefs.SetInt("HighScore", scoreObject.getScore());
                    }
                    SceneManager.LoadScene("GameOver");
                    /*var filetxt = File.CreateText("ScoreData.txt");
                    filetxt.WriteLine(scoreObject.getScore());
                    filetxt.Close();*/
                }
            }
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (i_frame.invin == false)
        {
            if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Enemy_Bullet" || collision.gameObject.tag == "Obstacles" || collision.gameObject.tag == "Window")
            {
                audiomanager.Play("Player_Hit");
                health--;
                i_frame.invin = true;
                Handheld.Vibrate();
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
            if (collision.gameObject.tag == "Enemy_Bullet" || collision.gameObject.tag == "Window")
            {
                health--;
                audiomanager.Play("Player_Hit");
                i_frame.invin = true;
                Handheld.Vibrate();
            }
        }
    }
}
