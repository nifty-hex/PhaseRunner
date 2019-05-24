using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    public GameObject flare;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.angularVelocity += 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Ground");
            Destroy(flare);
        }
    }
}
