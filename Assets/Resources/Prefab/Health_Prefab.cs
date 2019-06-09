﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Prefab : MonoBehaviour
{
    public int health;
    public I_Frames i_frame;

    public float time_slowness = 0.5f;
    public float time_fix_mul;

    public GameObject bg;
    public float change_speed;
    public float bg_y_offset;
    Color tmp;
    bool die = false;

    public float time_till_scene_change = 3f;

    void Update()
    {
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

                }
            }
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