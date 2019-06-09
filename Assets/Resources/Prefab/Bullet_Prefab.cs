using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Prefab : MonoBehaviour
{
    public float speed;
    public float life_time;
    private Rigidbody2D rb2d;
    public float rotateSpeed = 400f;
    public int bulletType = 0; //1 home, 2 explode (explode is dangerous)

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Vector3 copy = rb2d.velocity;
        copy += transform.right * speed;
        rb2d.velocity = copy;
    }

    void Update()
    {
        life_time -= Time.deltaTime;
        if (life_time <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacles" || collision.gameObject.tag == "Enemy_Bullet")
        {
            //Destroy(collision.gameObject);
        }
        //Destroy(gameObject);
    }
}
