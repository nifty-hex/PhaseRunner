using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    public Animator animator;
    public GameObject explosion;

    private Drop_Items drop_item;
    // Start is called before the first frame update

    void Start()
    {
        drop_item = GameObject.Find("Item_Spawn").GetComponent<Drop_Items>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Obstacles")
        {
            animator.SetBool("Ground", true);
        }
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (collision.gameObject.tag == "Player_Bullet")
        {
            drop_item.will_drop = true;
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (drop_item.will_drop)
        {
            drop_item.spawn_point.position = transform.position;
        }
    }
}
