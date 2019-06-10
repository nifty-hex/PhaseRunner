﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{

    public int max_enemy_num;
    public int number_of_enemies;
    public float camera_x_offset;
    public float camera_y_offset;
    public float spawn_rate_time;
    public float spawn_rate;
    public GameObject player;
    int enemy_id;
    public GameObject common_enemy_1; //Drones
    public GameObject common_enemy_2; //Charger
    public GameObject common_enemy_3; //Boomer

    public EnemyFactory enfact;

    // Start is called before the first frame update
    void Start()
    {
        spawn_rate_time = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //Commons

        spawn_rate_time += Time.deltaTime * 100;
        if (number_of_enemies <= max_enemy_num)
        {
            if (spawn_rate_time > spawn_rate)
            {
                enemy_id = Random.Range(0, 4);
                enfact.buildEnemy(enemy_id);
		number_of_enemies++;
                spawn_rate_time = 0;
            }
        }
    }
}
