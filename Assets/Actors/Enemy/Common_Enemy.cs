﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common_Enemy : MonoBehaviour, EnemyInterface
{
    public int hp;
    public float x_speed;
    public float x_speed_limit;
    public float y_speed;

    private GameObject player;
    public GameObject bullet;
    public GameObject enemyExplosion;
    public GameObject enemyFlash;
    public GameObject flashSpawnPoint;
    public Animator animator;

    public float fireRateTime;
    public float fireRate;

    private Rigidbody2D rigidBody;
    public Vector3 offset;

    private Enemy_Spawn en_spawn;
    private Drop_Items drop_item;

    private AudioManager audiomanager;

    // Start is called before the first frame update
    void Start()
    {
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        player = GameObject.Find("Player");
        en_spawn = GameObject.Find("Main Camera").GetComponent<Enemy_Spawn>();
        drop_item = GameObject.Find("Item_Spawn").GetComponent<Drop_Items>();
        fireRateTime = 0;
        rigidBody = GetComponent<Rigidbody2D>();
        audiomanager.Play("Common_Idle");
    }

    // Update is called once per frame
    void Update()
    {
        CheckMove();
        CheckHealth();
        CheckDrop();
        CheckShoot();
    }

    // Used for animation
    void FixedUpdate()
    {
        CheckRotation();
    }

    public void CheckMove() {
        if (rigidBody.velocity.x < x_speed_limit)
        {
            rigidBody.AddForce(new Vector2(x_speed, 0), ForceMode2D.Impulse);
        }
    }

    public void CheckShoot() {
        fireRateTime += Time.deltaTime * 100;
        if (fireRateTime > fireRate)
        {
            Instantiate(bullet, flashSpawnPoint.transform.position, flashSpawnPoint.transform.rotation);
            Instantiate(enemyFlash, flashSpawnPoint.transform.position, flashSpawnPoint.transform.rotation);
            audiomanager.Play("Common_Shoot");
            fireRateTime = 0;
        }
    }

    public void CheckHealth() {
        if (hp <= 0)
        {
            en_spawn.number_of_enemies--;
            Instantiate(enemyExplosion, transform.position, transform.rotation);
            drop_item.will_drop = true;
            audiomanager.Play("PlaceHolderExplosion");
            audiomanager.Stop("Common_Idle");
            Destroy(gameObject);
        }
    }

    public void CheckRotation() {
        if (Vector3.Distance(transform.position, player.transform.position) > 7)
        {
            animator.SetInteger("Pose", 0);
        }
        else if (Vector3.Distance(transform.position, player.transform.position) > 3)
        {
            animator.SetInteger("Pose", 1);
        }
        else
        {
            animator.SetInteger("Pose", 2);
        }

        if (transform.position.x < player.transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        Vector3 desiredPosition = player.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, y_speed * Time.deltaTime);
        transform.position = new Vector2(transform.position.x,smoothedPosition.y);
    }

    public void CheckDrop() {
        if (drop_item.will_drop)
        {
            drop_item.spawn_point.position = transform.position;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player_Bullet")
        {
            audiomanager.Play("Enemy_Hit");
            hp--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player_Bullet")
        {
            audiomanager.Play("Enemy_Hit");
            hp--;
        }
    }
}
