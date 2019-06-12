using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class window : MonoBehaviour
{
    public Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player_Bullet" || collision.gameObject.tag == "Player" )
        {
            animator.SetBool("broke", true);
            Destroy(gameObject, 0.125f);
        }
    }
}
