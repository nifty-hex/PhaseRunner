using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_destroy : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Firewall")
            Destroy(collision.gameObject);
    }
}


