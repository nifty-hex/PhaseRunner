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
    public GameObject enemyExplosion;


    private Enemy_Spawn en_spawn;
    private Drop_Items drop_item;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        en_spawn = GameObject.Find("Main Camera").GetComponent<Enemy_Spawn>();
        drop_item = GameObject.Find("Item_Spawn").GetComponent<Drop_Items>();
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
            if (rigidBody.velocity.x == 0)
            {
                print("Charger Dead by Stop");
                en_spawn.number_of_enemies--;
                Destroy(gameObject);
            }
        }
    }

    void FixedUpdate()
    {
        if (hp <= 0 && gameObject.name == "Charger(Clone)")
        {
            en_spawn.number_of_enemies--;
            Instantiate(enemyExplosion, transform.position, transform.rotation);
            drop_item.will_drop = true;
            Destroy(gameObject);
        }
        if (drop_item.will_drop)
        {
            drop_item.spawn_point.position = transform.position;
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
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Player")
        {
            Instantiate(enemyExplosion, transform.position, transform.rotation);
            en_spawn.number_of_enemies--;
            Destroy(gameObject);
        }
    }
}
