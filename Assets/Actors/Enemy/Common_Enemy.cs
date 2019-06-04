using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common_Enemy : MonoBehaviour
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


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        en_spawn = GameObject.Find("Main Camera").GetComponent<Enemy_Spawn>();
        drop_item = GameObject.Find("Item_Spawn").GetComponent<Drop_Items>();
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
            Instantiate(bullet, flashSpawnPoint.transform.position, flashSpawnPoint.transform.rotation);
            Instantiate(enemyFlash, flashSpawnPoint.transform.position, flashSpawnPoint.transform.rotation);
            SoundManagerScript.PlaySound("super pew");
            fireRateTime = 0;
        }
    }

    void FixedUpdate()
    {
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
        if (hp <= 0)
        {
            en_spawn.number_of_enemies--;
            Instantiate(enemyExplosion, transform.position, transform.rotation);
            drop_item.will_drop = true;
            SoundManagerScript.PlaySound("Explosion");
            Destroy(gameObject);
        }
        if (drop_item.will_drop)
        {
            drop_item.spawn_point.position = transform.position;
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
