using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon_UI : MonoBehaviour
{

    public Player_shoot shoot;
    public Text ammo_count_txt;
    public Animator animator;
    public int id; //1 = Weapon Sprite.  2 = Ammo Count

    // Update is called once per frame
    void Update()
    {
        if (id == 1)
        {
            animator.SetInteger("Gun", shoot.gunType);
        }

        if (id == 2)
        {
            if (shoot.gunType == 0)
            {
                ammo_count_txt.text = "∞";
            }
            else
            {
                ammo_count_txt.text = shoot.ammo[shoot.gunType] + " / " + shoot.maxAmmo(shoot.gunType);
            }
        }
    }
}
