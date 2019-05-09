﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common_Enemy : MonoBehaviour
{
    public int hp;
    public float x_speed;
    public float x_speed_limit;
    public float y_speed;

    public GameObject player;
    public GameObject bullet;

    public float fireRateTime;
    public float fireRate;
    public float firePoint_y_offset;

    private Rigidbody2D rigidBody;
    public Vector3 offset;
    float x_scale;

    // Start is called before the first frame update
    void Start()
    {
        x_scale = transform.localScale.x;
        print("0.62");
        fireRateTime = 0;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "Common_Enemy")
        {
            transform.position = new Vector2(player.transform.position.x+100, player.transform.position.y);
        }
        if (gameObject.name == "Common_Enemy(Clone)")
        {
            if (rigidBody.velocity.x < x_speed_limit)
            {
                rigidBody.AddForce(new Vector2(x_speed, 0), ForceMode2D.Impulse);
            }
            fireRateTime += Time.deltaTime * 100;
            if (fireRateTime > fireRate)
            {
                print("shoot");
                Instantiate(bullet, new Vector2(transform.position.x, transform.position.y + firePoint_y_offset), Quaternion.identity);
                fireRateTime = 0;
            }
        }
    }

    void FixedUpdate()
    {
        if (transform.position.x > player.transform.position.x)
        {
            Vector3 lTemp = transform.localScale;
            lTemp.x = x_scale;
            transform.localScale = lTemp;
        }
        else
        {
            Vector3 lTemp = transform.localScale;
            lTemp.x = -x_scale;
            transform.localScale = lTemp;
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
        Vector3 desiredPosition = player.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, y_speed * Time.deltaTime);
        transform.position = new Vector2(transform.position.x,smoothedPosition.y);
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
