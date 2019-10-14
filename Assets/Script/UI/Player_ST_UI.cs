using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ST_UI : MonoBehaviour
{

    public Slow_Time timeslow;
    float max_time_meter;
    public float transparent_meter;

    void Update()
    {
        gameObject.transform.localScale = new Vector3(timeslow.getCurrentAmountLeft() / timeslow.getCapacity(), transform.localScale.y, transform.localScale.z);
    }
}

