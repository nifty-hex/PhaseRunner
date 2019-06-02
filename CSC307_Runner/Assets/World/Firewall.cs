using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firewall : MonoBehaviour {

    public GameObject player;
    public Player_Health hp;

    public float speed;
    public float speed_limit;
    float normal_speed;
    public float high_speed;
    public float low_speed;
    public float slow_speed_limit;
    public float distance;
    public float max_distance;
    public float min_distance;

    private Rigidbody2D rigidBody;
    public Enemy_Spawn en_spawn;

    // Use this for initialization
    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        normal_speed = speed;
    }

    // Update is called once per frame
    void Update() {
        Slow_Time playerScript = player.GetComponent<Slow_Time>();
        distance = player.transform.position.x - transform.position.x;
        if (rigidBody.velocity.x <= speed_limit)
            rigidBody.AddForce(new Vector2(speed, 0), ForceMode2D.Impulse);
        if (playerScript.is_time_slow)
        {
            speed = slow_speed_limit;
        }
        else
        {
            if (distance > max_distance)
            {
                speed = high_speed;
            }
            else if (distance < min_distance)
            {
                speed = low_speed;
            }
            else
            {
                speed = normal_speed;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hp.health = 0;
        }
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Obstacles" ||
            collision.gameObject.tag == "Banners" || collision.gameObject.tag == "Enemy_Bullet" ||
             collision.gameObject.tag == "Charger_Jump_Point" || collision.gameObject.tag == "Player_Bullet")
        {
            if (collision.gameObject.tag == "Enemy")
                en_spawn.number_of_enemies--;
            Destroy(collision.gameObject);
        }
    }
}
