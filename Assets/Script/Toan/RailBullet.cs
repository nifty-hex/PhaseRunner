using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailBullet : MonoBehaviour
{
    private float fadeRate = 0.07f;
    private float alpha = 1f;
    public SpriteRenderer render;
    private AudioManager audiomanager;

    private void Start()
    {
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        audiomanager.Play("Gun_Rail");
    }

    // Update is called once per frame
    void Update()
    {

        if (alpha > 0)
        {
            alpha -= fadeRate;
            Color newColor = render.color;
            newColor.a = alpha;
            render.color = newColor;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacles" || collision.gameObject.tag == "Enemy_Bullet")
        {
            Destroy(collision.gameObject);
        }
    }

}
