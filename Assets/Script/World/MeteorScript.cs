using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    public Animator animator;
    public GameObject explosion;
    private AudioManager audiomanager;
    private bool visible = false;
    private bool onground = false;
    private bool playedDrop = false;
    private bool playedBurn = false;
    private Drop_Items drop_item;
    public AudioSource meteor_drop;
    public AudioSource meteor_burn;

    void Start()
    {
        drop_item = GameObject.Find("Item_Spawn").GetComponent<Drop_Items>();
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    private void Update()
    {
        if (visible && !onground && !playedDrop)
        {
            
            meteor_drop.Play();
            playedDrop = true;
        }
        else if (visible && onground && !playedBurn)
        {
            meteor_burn.Play();
            playedBurn = true;
        }
        else if (!visible)
        {
            meteor_burn.Stop();
        }
        meteor_drop.volume = 0.3f * audiomanager.getSFXMult();
        meteor_burn.volume = 0.2f * audiomanager.getSFXMult();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Obstacles")
        {
            onground = true;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player_Bullet")
        {
            drop_item.will_drop = true;
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (collision.gameObject.name == "MeteorBarrier")
        {
            Destroy(this);
        }
    }

    private void OnBecameVisible()
    {
        visible = true;
    }

    private void OnBecameInvisible()
    {
        visible = false;
    }
}
