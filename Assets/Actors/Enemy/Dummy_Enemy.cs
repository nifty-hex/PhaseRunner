using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy_Enemy : MonoBehaviour
{
    public DummyCounter dumCounter;

    public float x_speed;
    public float x_speed_limit;
    public float y_speed;

    private GameObject player;
    public GameObject enemyExplosion;
    public Animator animator;

    private Rigidbody2D rigidBody;
    public Vector3 offset;

    private AudioManager audiomanager;
    bool got_hit;

    // Start is called before the first frame update
    void Start()
    {
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        player = GameObject.Find("Player");
        
        rigidBody = GetComponent<Rigidbody2D>();
        audiomanager.Play("Common_Idle");
    }

    // Update is called once per frame

    public void Update()
    {
        /*
        if (rigidBody.velocity.x < x_speed_limit)
        {
            rigidBody.AddForce(new Vector2(x_speed, 0), ForceMode2D.Impulse);
        }

        
        Vector3 desiredPosition = player.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, y_speed * Time.deltaTime);
        transform.position = new Vector2(transform.position.x, smoothedPosition.y);
        */

        if (got_hit)
        {
            got_hit = false;
            audiomanager.Play("Enemy_Hit");
            Instantiate(enemyExplosion, transform.position, transform.rotation);
            audiomanager.Play("PlaceHolderExplosion");
            audiomanager.Stop("Common_Idle");
            dumCounter.num_of_enemy--;
            Destroy(gameObject);
        }
    }
    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player_Bullet")
        {
            got_hit = true;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player_Bullet")
        {
            got_hit = true;
            Destroy(collision.gameObject);
        }
    }
}
