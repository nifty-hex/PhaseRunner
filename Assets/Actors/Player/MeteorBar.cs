using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBar : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Meteor(Clone)")
        {
            Destroy(collision.gameObject);
        }
    }
}
