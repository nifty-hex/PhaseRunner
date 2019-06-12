using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomer_Splat : MonoBehaviour
{

    public GameObject shockwave;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
