using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common_Enemy_Prefab : MonoBehaviour
{
    public int hp;
    public float x_speed;
    public float x_speed_limit;
    public float y_speed;

    public GameObject player;
    public GameObject bullet;

    public float fireRateTime;
    public float fireRate;

    private Rigidbody2D rigidBody;
    public Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        fireRateTime = 0;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidBody.velocity.x < x_speed_limit)
        {
            rigidBody.AddForce(new Vector2(x_speed, 0), ForceMode2D.Impulse);
        }
        fireRateTime += Time.deltaTime * 100;
        if (fireRateTime > fireRate)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            fireRateTime = 0;
        }
    }

    void FixedUpdate()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player_Bullet")
        {
            hp--;
            Destroy(collision.gameObject);
        }
    }
}
