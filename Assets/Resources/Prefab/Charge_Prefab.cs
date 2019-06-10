using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test{
public class Charge_Prefab : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public int hp;
    public float speed;
    public float speed_limit;
    public float jump_force;
    public GameObject enemyExplosion;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        gameObject.transform.position = new Vector2(x -= 10, transform.position.y);
    }

    void FixedUpdate()
    {
        if (hp <= 0)
        {
            Instantiate(enemyExplosion, transform.position, transform.rotation);
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
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Player")
        {
            Instantiate(enemyExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
}