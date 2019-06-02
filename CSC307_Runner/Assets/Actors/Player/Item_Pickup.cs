using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Pickup : MonoBehaviour
{
    public Player_Health play_health;
    public Player_shoot play_shoot;

    public int machine_gun_ammo;
    public int shotgun_ammo;
    public int railgun_ammo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Health(Clone)")
        {
            if (play_health.health < 3)
            {
                play_health.health++;
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "Ammo(Clone)")
        {

            play_shoot.ammo[1] += machine_gun_ammo;
            if (play_shoot.ammo[1] > 200)
            {
                play_shoot.ammo[1] = 200;
            }
            play_shoot.ammo[2] += shotgun_ammo;
            if (play_shoot.ammo[2] > 50)
            {
                play_shoot.ammo[2] = 50;
            }
            
            //play_shoot.ammo[3] += railgun_ammo;
            Destroy(collision.gameObject);
        }
        
    }
}
