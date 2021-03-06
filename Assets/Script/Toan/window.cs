﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class window : MonoBehaviour
{
    public Animator animator;
    public GameObject glassBreak;
    private AudioManager audiomanager;

    private void Start()
    {
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player_Bullet" || collision.gameObject.tag == "Player" )
        {
            audiomanager.Play("Window_Break");
            animator.SetBool("broke", true);
            Destroy(gameObject, 0.125f);
            Instantiate(glassBreak, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player_Bullet" || collision.gameObject.tag == "Player")
        {
            audiomanager.Play("Window_Break");
            animator.SetBool("broke", true);
            Destroy(gameObject, 0.125f);
            Instantiate(glassBreak, transform.position, transform.rotation);

        }
    }
}
