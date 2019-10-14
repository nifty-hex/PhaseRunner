using System.Collections;
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
    public float spawn_refresh_rate;
    public int spawn_type = 2;
    public GameObject player;
    int enemy_id;

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

        spawn_rate_time += Time.deltaTime * spawn_refresh_rate;
        if (number_of_enemies <= max_enemy_num)
        {
            if (spawn_rate_time > spawn_rate)
            {
                //enemy_id = Random.Range(0, 4);
                enfact.buildEnemy(enemy_id);
                enemy_id = Random.Range(0, spawn_type); //max = 8, starts at 2
                enfact.buildEnemy(enemy_id);
                number_of_enemies++;
                spawn_rate_time = 0;
            }
        }
    }
}
