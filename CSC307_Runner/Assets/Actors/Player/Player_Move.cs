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
    public bool can_move;
    public bool can_jump;
    public bool can_double_jump;
    public float standard_gravity;
    public float gliding_gravity;
    private Rigidbody2D rigidBody;

    public bool is_hit;
    public float hit_recover_time;
    float normal_hit_recover_time;

    // Use this for initialization
    void Start()
    {
        //Debug.Log("Version 0.0.128");
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
                Debug.Log("Restored");
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
            }
            else if (Input.GetKeyDown(KeyCode.Space) && can_jump == false && can_double_jump)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
                rigidBody.AddForce(new Vector2(0, double_jump_force), ForceMode2D.Impulse);
                can_double_jump = false;
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
        }
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("CRASH!!!");
            can_double_jump = false;
        }
        if (collision.gameObject.tag == "Obstacles")
        {
            Debug.Log("Hit Obs");
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
