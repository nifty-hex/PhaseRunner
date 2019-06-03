using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common_Bullet : MonoBehaviour
{ 
    //private GameObject player;
    private GameObject player_offset;
    public float speed;
    public float life_time;
    public float x_velocity_limit;
    float temp_life;
    //private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        player_offset = GameObject.Find("Aim_At");
        transform.LookAt(player_offset.transform);
        transform.Rotate(0, 90, 0);
        temp_life = life_time;
    }

    // Update is called once per frame
    void Update()
    {
        life_time -= Time.deltaTime * 100;
        if (life_time <= 0)
        {
            Destroy(gameObject);
            life_time = temp_life;
        }
        transform.Translate(new Vector3(-1, 0 ,0) * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Wall" || 
            collision.gameObject.tag == "Player_Bullet")
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}


