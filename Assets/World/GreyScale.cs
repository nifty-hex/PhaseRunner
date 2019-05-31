using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GreyScale : MonoBehaviour
{
    public float current_alpha = 0;
    public float bw_alpha = 0.5f;
    public float standard_alpha = 0;
    public float change_speed;
    public GameObject bg;
    public Slow_Time slow_time;
    Color tmp;

    // Start is called before the first frame update
    void Start()
    {
        print("0.26");
        tmp = bg.GetComponent<SpriteRenderer>().color;
        tmp.a = 0;
        bg.GetComponent<SpriteRenderer>().color = tmp;
    }

    // Update is called once per frame
    void Update()
    {
        current_alpha = tmp.a;
        if (Time.timeScale > slow_time.time_slowness)
        {
            tmp = bg.GetComponent<SpriteRenderer>().color;
            if (tmp.a < bw_alpha)
            {
                tmp.a += Time.deltaTime * change_speed;
            }
            if (tmp.a >= bw_alpha)
            {
                bg.GetComponent<SpriteRenderer>().color = tmp;
            }
        }
        else if(Time.timeScale < 1.0f)
        {
            tmp = bg.GetComponent<SpriteRenderer>().color;
            if (tmp.a > standard_alpha)
            {
                tmp.a -= Time.deltaTime * change_speed;
            }
            if (tmp.a <= standard_alpha)
            {
                bg.GetComponent<SpriteRenderer>().color = tmp;
            }
        }
    }
}


