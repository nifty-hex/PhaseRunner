using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    public float life_time;
    private Rigidbody2D rb2d;
    public GameObject gun;
    public float rotateSpeed = 400f;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
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
        rb2d.velocity = transform.right * speed;
        if (transform.localScale.x <= 5f)
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);//or destroy whichever works better

            if (transform.localScale.x >= 10f)
            {
                for (int a = 0; a < 8; a++)
                {
                    GameObject bullet = Instantiate(this.gameObject, transform.position, transform.rotation);
                    bullet.transform.localScale = new Vector3(bullet.transform.localScale.x - 5f, bullet.transform.localScale.y - 5f, bullet.transform.localScale.z);
                    bullet.GetComponent<Rigidbody2D>().rotation += a * (360 / 8);
                }
            }
            gameObject.SetActive(false); //turn off the bullet
        }
        else
        {

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacles")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Banners")
        {
            Destroy(gameObject);
        }
    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
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
        return closest;
    }
}
