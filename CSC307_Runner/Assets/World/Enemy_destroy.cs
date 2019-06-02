using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_destroy : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Enemy_Bullet")
            Destroy(collision.gameObject);
    }
}