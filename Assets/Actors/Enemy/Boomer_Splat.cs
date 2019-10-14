using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomer_Splat : MonoBehaviour
{

    public GameObject shockwave;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Instantiate(shockwave, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }

    void OnBecameInvisible()
    {
        if (gameObject.name == "Common_Bullet(Clone)")
            Destroy(gameObject);
    }
}
