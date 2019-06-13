using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomer_Enemy : MonoBehaviour, EnemyInterface
{
    private GameObject player;
    public GameObject splatters;
    private Enemy_Spawn en_spawn;
    public GameObject enemyExplosion;


    public int max_splatters;
    public int hp;
    public float x_speed;
    public float x_speed_limit;
    public float y_speed;
    public Vector3 offset;

    private Rigidbody2D rigidBody;

    private Drop_Items drop_item;


    // Start is called before the first frame update
    void Start()
    {
        en_spawn = GameObject.Find("Main Camera").GetComponent<Enemy_Spawn>();
        drop_item = GameObject.Find("Item_Spawn").GetComponent<Drop_Items>();
        player = GameObject.Find("Player");
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    	CheckMove();
        CheckHealth();
        CheckDrop();
    }

    public void CheckMove() {
    	if (rigidBody.velocity.x < x_speed_limit)
        {
            rigidBody.AddForce(new Vector2(x_speed, 0), ForceMode2D.Impulse);
        }
        Vector3 desiredPosition = player.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, y_speed * Time.deltaTime);
        transform.position = new Vector2(transform.position.x, smoothedPosition.y);
    }

    public void CheckHealth() {
    	if (hp <= 0)
        {
            en_spawn.number_of_enemies--;
            Instantiate(enemyExplosion, transform.position, transform.rotation);
            drop_item.will_drop = true;
            SoundManagerScript.PlaySound("boomer die");
            Destroy(gameObject);
        }
    }

    public void CheckDrop() {
    	if (drop_item.will_drop)
        {
            drop_item.spawn_point.position = transform.position;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player_Bullet")
        {
            for (int i = 0; i < max_splatters; i++)
            {
                SoundManagerScript.PlaySound("super pew 2");
                Instantiate(splatters, transform.position, Quaternion.identity);
            }
            SoundManagerScript.PlaySound("boomer hit");
            hp--;
        }
    }
}
