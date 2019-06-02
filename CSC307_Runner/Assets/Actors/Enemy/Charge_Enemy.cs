using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge_Enemy : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public int hp;
    public float speed;
    public float speed_limit;
    public float jump_force;

    private Enemy_Spawn en_spawn;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        en_spawn = GameObject.Find("Main Camera").GetComponent<Enemy_Spawn>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "Charger(Clone)")
        {
            if (rigidBody.velocity.x > speed_limit)
            {
                rigidBody.AddForce(new Vector2(-speed, 0), ForceMode2D.Impulse);
            }
            if (speed == 0)
            {
                print("Dead by Stop");
                Destroy(gameObject);
            }
        }
    }

    void FixedUpdate()
    {
        if (hp <= 0 && gameObject.name == "Charger(Clone)")
        {
            en_spawn.number_of_enemies--;
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Charger_Jump_Point")
        {
            rigidBody.AddForce(new Vector2(0, jump_force), ForceMode2D.Impulse);
        }
        if (collision.gameObject.tag == "Player_Bullet" || collision.gameObject.tag == "Obstacles")
        {
            hp--;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Wall")
        {
            en_spawn.number_of_enemies--;
            Destroy(gameObject);
        }
    }
}
