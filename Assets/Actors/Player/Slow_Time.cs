using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow_Time : MonoBehaviour {

    public float time_scale_tracker;
    public float time_slowness;
    public float time_fix_mul;
    public float time_restore_speed;
    public float time_loss_speed;
    public float time_slow_limit;
    public float normal_time_slow_limit;
    public bool over_limit;
    public bool is_time_slow;
    public bool slow_sound_played = false;
    public bool speed_sound_played = false;

    public float current_alpha = 0;
    public float bw_alpha = 0.5f;
    public float standard_alpha = 0;
    public float change_speed;
    public GameObject bg;
    public float bg_y_offset;
    Color tmp;

    // Use this for initialization
    void Start () {
        bg.transform.position = new Vector3(bg.transform.position.x, bg_y_offset, bg.transform.position.z);
        normal_time_slow_limit = time_slow_limit;
        tmp = bg.GetComponent<SpriteRenderer>().color;
        tmp.a = 0;
        bg.GetComponent<SpriteRenderer>().color = tmp;
    }
	
	// Update is called once per frame
	void Update () {
        time_scale_tracker = Time.timeScale;
        if (Input.GetKey(KeyCode.LeftShift) && time_slow_limit > 0 && over_limit == false)
        {
            time_slow_limit -= (Time.deltaTime * time_loss_speed);
            is_time_slow = true;
            if (Time.timeScale > time_slowness)
            {
                Time.timeScale -= (Time.deltaTime * time_fix_mul);
                
                /*
                tmp.a = bw_alpha;
                bg.GetComponent<SpriteRenderer>().color = tmp;
                */
            }
        }
        else
        {
            is_time_slow = false;
            if (Time.timeScale < 1.0f)
            {
                Time.timeScale += (Time.deltaTime * time_fix_mul);
                
                /*
                tmp.a = standard_alpha;
                bg.GetComponent<SpriteRenderer>().color = tmp;
                */
            }
        }

        if (is_time_slow)
        {
            if (slow_sound_played == false)
            {
                SoundManagerScript.PlaySound("slow down");
                slow_sound_played = true;
                GameObject.Find("MusicManager").GetComponent<MusicManagerScript>().pitch = 0.5f;
                GameObject.Find("SoundManager").GetComponent<SoundManagerScript>().pitch = 0.5f;
            }
        
            tmp = bg.GetComponent<SpriteRenderer>().color;
            if (tmp.a < bw_alpha)
            {
                tmp.a += change_speed;
            }
            bg.GetComponent<SpriteRenderer>().color = tmp;
        }
        else
        {
            tmp = bg.GetComponent<SpriteRenderer>().color;
            if(slow_sound_played)
            {
                SoundManagerScript.PlaySound("speed up");
                slow_sound_played = false;
                GameObject.Find("MusicManager").GetComponent<MusicManagerScript>().pitch = 1.0f;
                GameObject.Find("SoundManager").GetComponent<SoundManagerScript>().pitch = 1.0f;
            }
            if (tmp.a > standard_alpha)
            {
                tmp.a -= change_speed;
            }
            bg.GetComponent<SpriteRenderer>().color = tmp;
        }

        if (time_slow_limit < normal_time_slow_limit)
            time_slow_limit += Time.deltaTime * time_restore_speed;
        if (time_slow_limit < 0)
            over_limit = true;
        if (time_slow_limit >= normal_time_slow_limit)
            over_limit = false;
        current_alpha = tmp.a;
    }
}
