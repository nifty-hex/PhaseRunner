using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firewall : MonoBehaviour {

    public GameObject player;
    public Player_Health hp;
    public Enemy_Spawn en_spawn;
    public PauseGame pausegame;
    public Slow_Time slowtime;

    public float low_speed;
    public float high_speed;
    public float max_distance;
   
    private Rigidbody2D rigidBody;
    private float speed;
    private float speed_limit;
    private float distance;

    // Use this for initialization
    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        speed = 0.6f;
    }

    // Update is called once per frame
    void Update() {
        if (!pausegame.isPaused())
        {
            distance = player.transform.position.x - transform.position.x;
            if (rigidBody.velocity.x <= speed_limit)
            {
                if (slowtime.isSlowed())
                {
                    rigidBody.AddForce(new Vector2(speed * slowtime.how_slow, 0), ForceMode2D.Impulse);
                }
                else
                {
                    rigidBody.AddForce(new Vector2(speed, 0), ForceMode2D.Impulse);
                }
            }
            if (distance > max_distance)
            {
                speed_limit = high_speed;
            }
            else if (distance < max_distance)
            {
                speed_limit = low_speed;
            }
        }  
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hp.health = 0;
        }
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Obstacles" ||
            collision.gameObject.tag == "Banners" || collision.gameObject.tag == "Enemy_Bullet" ||
            collision.gameObject.tag == "Charger_Jump_Point" || collision.gameObject.tag == "Player_Bullet" ||
            collision.gameObject.tag == "Item_Pickup")

        {
            if (collision.gameObject.tag == "Enemy")
                en_spawn.number_of_enemies--;
            Destroy(collision.gameObject);
        }
    }
}
