using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon_UI : MonoBehaviour
{

    public Player_shoot shoot;
    public Text ammo_count_txt;

    public Sprite pistol;
    public Sprite machine_gun;
    public Sprite shotgun;
    public Sprite railgun;
    public int id; //1 = Weapon Sprite.  2 = Ammo Count


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (id == 1)
        {
            if (shoot.gunType == 0) //Pistol
            {
                GetComponent<Image>().sprite = pistol;
            }
            if (shoot.gunType == 1) //Machine Gun
            {
                GetComponent<Image>().sprite = machine_gun;
            }
            if (shoot.gunType == 2) //Shotgun
            {
                GetComponent<Image>().sprite = shotgun;
            }
            if (shoot.gunType == 3) //Railgun
            {
                GetComponent<SpriteRenderer>().sprite = railgun;
            }
        }

        if (id == 2)
        {
            if (shoot.gunType == 0)
            {
                ammo_count_txt.text = "∞";
            }
            if (shoot.gunType == 1)
            {
                ammo_count_txt.text = "" + shoot.ammo[1];
            }
            if (shoot.gunType == 2)
            {
                ammo_count_txt.text = "" + shoot.ammo[2];
            }
            if (shoot.gunType == 3)
            {
                ammo_count_txt.text = "" + shoot.ammo[3];
            }
        }
    }
}
