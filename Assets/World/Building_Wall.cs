using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_Wall : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacles")
        {
            Destroy(collision.gameObject);
        }
    }
}
