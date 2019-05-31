using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HP_UI : MonoBehaviour
{
    public Player_Health player;
    public GameObject hp_1, hp_2, hp_3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.health >= 3)
        {
            hp_1.SetActive(true);
            hp_2.SetActive(true);
            hp_3.SetActive(true);
        }
        else if (player.health == 2)
        {
            hp_1.SetActive(true);
            hp_2.SetActive(true);
            hp_3.SetActive(false);
        }
        else if (player.health == 1)
        {
            hp_1.SetActive(true);
            hp_2.SetActive(false);
            hp_3.SetActive(false);
        }
        else
        {
            hp_1.SetActive(false);
            hp_2.SetActive(false);
            hp_3.SetActive(false);
        }
    }
}

