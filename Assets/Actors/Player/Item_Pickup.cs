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

    private AudioManager audiomanager;

    // Start is called before the first frame update
    void Start()
    {
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Health(Clone)")
        {
            if (play_health.health < 3 && !play_health.die)
            {
                play_health.health++;
            }
            audiomanager.Play("Player_Heart");
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "Ammo(Clone)")
        {

            play_shoot.ammo[1] += machine_gun_ammo;
            if (play_shoot.ammo[1] > play_shoot.maxAmmo(1))
            {
                play_shoot.ammo[1] = play_shoot.maxAmmo(1);
            }
            play_shoot.ammo[2] += shotgun_ammo;
            if (play_shoot.ammo[2] > play_shoot.maxAmmo(2))
            {
                play_shoot.ammo[2] = play_shoot.maxAmmo(1);
            }
            play_shoot.ammo[3] += railgun_ammo;
            if (play_shoot.ammo[3] > play_shoot.maxAmmo(3))
            {
                play_shoot.ammo[3] = play_shoot.maxAmmo(3);
            }

            audiomanager.Play("Player_Ammo");
            Destroy(collision.gameObject);
        }
        
    }
}
