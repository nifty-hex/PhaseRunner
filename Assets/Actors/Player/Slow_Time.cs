using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow_Time : MonoBehaviour
{
    private bool slowed = false;
    public float how_slow = 0.5f;
    public float restore_speed = 0.4f;
    public float loss_speed = 1f;
    private float time_slow_amount_left;
    public float time_slow_capacity;
    private bool over_limit;
    private bool soundPlayed = false;
    private float bw_alpha = 0.2f;
    private float standard_alpha = 0f;
    private float change_speed = 0.01f;
    public GameObject bg;
    private float bg_y_offset = 6.62f;
    private AudioManager audiomanager;
    private InputManager inputmanager;
    private PauseGame pausegame;
    Color tmp;

    void Start ()
    {
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        inputmanager = GameObject.Find("InputManager").GetComponent<InputManager>();
        pausegame = GameObject.Find("SettingsBorder").GetComponent<PauseGame>();
        bg.transform.position = new Vector3(bg.transform.position.x, bg_y_offset, bg.transform.position.z);
        time_slow_amount_left = time_slow_capacity;
        tmp = bg.GetComponent<SpriteRenderer>().color;
        tmp.a = 0;
        bg.GetComponent<SpriteRenderer>().color = tmp;
    }
	
	void Update ()
    {
        if (!pausegame.isPaused())
        {
            if (inputmanager.TimeSlow() && time_slow_amount_left > 0 && over_limit == false)
            {
                slowed = true;
                time_slow_amount_left -= (Time.deltaTime * loss_speed);
                Time.timeScale = how_slow;
                if (!soundPlayed)
                {
                    audiomanager.Play("Time_Down");
                    soundPlayed = true;
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
                slowed = false;
                Time.timeScale = 1f;
                if (soundPlayed)
                {
                    audiomanager.Play("Time_Up");
                    soundPlayed = false;
                }
                tmp = bg.GetComponent<SpriteRenderer>().color;
                if (tmp.a > standard_alpha)
                {
                    tmp.a -= change_speed;
                }
                bg.GetComponent<SpriteRenderer>().color = tmp;
            }
        }
        
        if (time_slow_amount_left < time_slow_capacity)
            time_slow_amount_left += Time.deltaTime * restore_speed;
        if (time_slow_amount_left < 0)
            over_limit = true;
        if (time_slow_amount_left >= time_slow_capacity)
            over_limit = false;
    }

    public float getCurrentAmountLeft()
    {
        return time_slow_amount_left;
    }

    public float getCapacity()
    {
        return time_slow_capacity;
    }

    public bool isSlowed()
    {
        return slowed;
    }
}
