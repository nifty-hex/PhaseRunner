using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ST_UI : MonoBehaviour
{

    public Slow_Time player;
    //time_slow_limit
    //over_limit
    float max_time_meter;
    public float transparent_meter;
    Color tmp;
    public GameObject bar_sprite;

    // Start is called before the first frame update
    void Start()
    {
        max_time_meter = player.time_slow_limit;
        tmp = bar_sprite.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = new Vector2(player.time_slow_limit / max_time_meter, transform.localScale.y);
    }

    void FixedUpdate()
    {
        if (player.over_limit)
        {
            tmp.a = transparent_meter;
            bar_sprite.GetComponent<SpriteRenderer>().color = tmp;
        }
        else
        {
            tmp.a = 1;
            bar_sprite.GetComponent<SpriteRenderer>().color = tmp;
        }
    }
}

