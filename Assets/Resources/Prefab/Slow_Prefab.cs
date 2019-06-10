using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow_Prefab : MonoBehaviour
{
    public float time_slow_time;
    public float upper_limit;
    public float lower_limit;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        time_slow_time = Time.timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = time_slow_time;
    }

    public void slowDown()
    {
        while (time_slow_time > lower_limit)
        {
            time_slow_time -= (Time.deltaTime);
        }
    }

    public void fastUp()
    {
        while (time_slow_time < upper_limit)
        {
            time_slow_time += (Time.deltaTime);
        }
    }
}
