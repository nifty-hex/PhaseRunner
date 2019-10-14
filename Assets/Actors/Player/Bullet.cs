using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    public float life_time;
    private Rigidbody2D rb2d;
    public float rotateSpeed = 400f;
    public int bulletType = 0; //1 home, 2 explode (explode is dangerous)
    public GameObject bulletExplode;
    private AudioManager audiomanager;

    // Use this for initialization
    void Start()
    {
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        rb2d = GetComponent<Rigidbody2D>();
        Vector3 copy = rb2d.velocity;
        copy += transform.right * speed;
        rb2d.velocity = copy;
    }

    void Update()
    {
        life_time -= Time.deltaTime;
        if (life_time <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    // The Update is called once per frame
    private void FixedUpdate()
    {
        //rb2d.velocity = transform.right * speed;
        //rb2d.AddForce(this.transform.right * speed * 1000);
        if (bulletType == 1)
        {
            Transform target = FindClosestEnemy().transform;
            Vector2 direction = (Vector2)target.position - rb2d.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, -transform.up).z;
            rb2d.angularVelocity = -rotateAmount * rotateSpeed;
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacles" || collision.gameObject.tag == "Ground")
        {
            audiomanager.Play("Ground_Hit");
        }
        else if (collision.gameObject.tag == "Window")
        {
            audiomanager.Play("Window_Hit");
        }

        if (collision.gameObject.tag == "Obstacles")
        {
            Destroy(collision.gameObject);
            audiomanager.Play("PlaceHolderExplosion");
        }
        else if (collision.gameObject.tag == "Enemy_Bullet")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag != "Player_Bullet")
        {
            Destroy(gameObject);
        }
        GameObject currentExplosion = Instantiate(bulletExplode, transform.position, transform.rotation);
        currentExplosion.transform.localScale = new Vector3(2f, 2f, 2f);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Window")
        {
            audiomanager.Play("Window_Hit");
        }
        GameObject currentExplosion = Instantiate(bulletExplode, transform.position, transform.rotation);
        currentExplosion.transform.localScale = new Vector3(2f, 2f, 2f);
        Destroy(gameObject);
    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos, gos1, gos2;
        gos = GameObject.FindGameObjectsWithTag("Enemy_Bullet");
        gos1 = GameObject.FindGameObjectsWithTag("Enemy");
        gos2 = GameObject.FindGameObjectsWithTag("Obstacles");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        foreach (GameObject go in gos1)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        foreach (GameObject go in gos2)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
