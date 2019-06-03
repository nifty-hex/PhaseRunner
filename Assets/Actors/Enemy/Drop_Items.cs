using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_Items : MonoBehaviour
{
    public GameObject health;
    public GameObject ammo;
    public Player_Health play_health;
    public bool will_drop;
    public Transform spawn_point;
    public int drop_item_chance; //That value out of 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (will_drop)
        {
            if (Random.Range(0,100) <= drop_item_chance && spawn_point != null)
            {
                if (play_health.health == 1)
                {
                    Instantiate(health, spawn_point.position, Quaternion.identity);
                }
                else if (play_health.health == 3)
                {
                    Instantiate(ammo, spawn_point.position, Quaternion.identity);
                }
                else
                {
                    if (Random.Range(0, 2) == 0) //Health
                    {
                        Instantiate(health, spawn_point.position, Quaternion.identity);
                    }
                    else //Ammo
                    {
                        Instantiate(ammo, spawn_point.position, Quaternion.identity);
                    }
                }
            }
            will_drop = false;
        }
    }
}
