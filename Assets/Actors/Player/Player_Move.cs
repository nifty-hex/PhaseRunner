using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Move : MonoBehaviour
{
    public float Y_Velocity;
    public float speed;
    public float speed_limit;
    public float low_speed_limit;
    public float high_speed_limit;
    float normal_speed_limit;
    public float jump_force;
    public float double_jump_force;
    private bool can_move;
    private bool can_jump;
    private bool can_double_jump;
    public float standard_gravity;
    public float gliding_gravity;
    private Rigidbody2D rigidBody;

    private bool is_hit;
    public float hit_recover_time;
    float normal_hit_recover_time;

    public Animator animator;
    public GameObject enemyExplosion;


    // Use this for initialization
    void Start()
    {
        Debug.Log("Version 0.0.153");
        rigidBody = GetComponent<Rigidbody2D>();
        standard_gravity = rigidBody.gravityScale;
        normal_speed_limit = speed_limit;
        normal_hit_recover_time = hit_recover_time;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_hit)
        {
            hit_recover_time -= Time.deltaTime;
            speed_limit = low_speed_limit;
            if (hit_recover_time <= 0)
            {
                speed_limit = normal_speed_limit;
                is_hit = false;
                hit_recover_time = normal_hit_recover_time;
            }
        }
        if (rigidBody.velocity.x < speed_limit)
        {
            rigidBody.AddForce(new Vector2(speed, 0), ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
        if (can_move)
        {
            Y_Velocity = rigidBody.velocity.y;
           
            //Standard Movement
            if (Input.GetKey("d"))
            {
                speed_limit = high_speed_limit;
            }
            else if (Input.GetKey("a"))
            {
                speed_limit = low_speed_limit;
            }
            else
            {
                speed_limit = normal_speed_limit;
            }

            //Jumping
            if (Input.GetKeyDown(KeyCode.Space) && can_jump)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
                rigidBody.AddForce(new Vector2(0, jump_force), ForceMode2D.Impulse);
                can_jump = false;
                animator.SetBool("jump", true);
            }
            else if (Input.GetKeyDown(KeyCode.Space) && can_jump == false && can_double_jump)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
                rigidBody.AddForce(new Vector2(0, double_jump_force), ForceMode2D.Impulse);
                can_double_jump = false;
                animator.SetBool("doublejump", true);

            }

            //Gliding
            if (Input.GetKey(KeyCode.Space))
            {
                if (rigidBody.velocity.y < 0 && can_jump == false)
                {
                    rigidBody.gravityScale = gliding_gravity;
                }
            }
            else
            {
                rigidBody.gravityScale = standard_gravity;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            can_jump = true;
            can_move = true;
            can_double_jump = true;
            rigidBody.gravityScale = standard_gravity;
            animator.SetBool("jump", false);
            animator.SetBool("doublejump", false);
        }
        if (collision.gameObject.tag == "Wall")
        {
            can_double_jump = false;
        }
        if (collision.gameObject.tag == "Obstacles" || collision.gameObject.tag == "Enemy_Bullet")
        {
            if (collision.gameObject.name == "Meteor")
            {
                Instantiate(enemyExplosion, transform.position, transform.rotation);
            }
            is_hit = true;
            Destroy(collision.gameObject);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            can_jump = false;
        }
    }
}
