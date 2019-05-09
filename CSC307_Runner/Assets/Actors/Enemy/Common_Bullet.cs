using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common_Bullet : MonoBehaviour
{ 
    public GameObject player;
    public GameObject player_offset;
    float speed;
    public float clone_speed;
    public float life_time;
    public float x_velocity_limit;
    float temp_life;
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(player_offset.transform);
        temp_life = life_time;
        rigidBody = GetComponent<Rigidbody2D>();
        if (gameObject.name == "Common_Bullet(Clone)")
        {
            speed = clone_speed;
        }
    }

    void LateUpdate()
    {
        if (gameObject.name == "Common_Bullet(Clone)")
        {
            //transform.LookAt(player.transform);
        }
    }

    // Update is called once pesr frame
    void Update()
    {
        life_time -= Time.deltaTime * 100;
        if (life_time <= 0)
        {
            Destroy(GameObject.Find("Common_Bullet(Clone)"));
            life_time = temp_life;
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Wall" || 
            collision.gameObject.tag == "Player_Bullet")
        {
            Destroy(GameObject.Find("Common_Bullet(Clone)"));
        }
    }
}

