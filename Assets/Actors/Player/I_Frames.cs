using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_Frames : MonoBehaviour
{
    public float i_frame_time;
    float temp_i_frame_time;
    public bool invin;
    Color tmp;
    public float i_frame_anim;
    float temp_i_frame_anim;

    // Start is called before the first frame update
    void Start()
    {
        temp_i_frame_time = i_frame_time;
        temp_i_frame_anim = i_frame_anim;
        invin = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (invin == true)
        {
            i_frame_time -= Time.deltaTime;
            if (i_frame_time <= 0)
            {
                invin = false;
                i_frame_time = temp_i_frame_time;
            }
        }
    }
    void FixedUpdate()
    {
        if (invin == true)
        {
            i_frame_anim++;
            if (i_frame_anim % 2 == 0)
            {
                tmp = gameObject.GetComponent<SpriteRenderer>().color;
                tmp.a = 0.25f;
                GetComponent<SpriteRenderer>().color = tmp;
            }
            else
            {
                tmp = gameObject.GetComponent<SpriteRenderer>().color;
                tmp.a = 0.75f;
                GetComponent<SpriteRenderer>().color = tmp;
            }
        }
        else
        {
            tmp = gameObject.GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            GetComponent<SpriteRenderer>().color = tmp;
        }
    }
}
