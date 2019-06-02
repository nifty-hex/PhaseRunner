using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    public Animator animator;
    public GameObject explosion;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Obstacles")
        {
            animator.SetBool("Ground", true);
        }
        if (collision.gameObject.tag == "Player_Bullet")
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
