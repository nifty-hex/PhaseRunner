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
    public GameObject player;
    public GameObject common_enemy_1;

    public float decrease_enemy_rate;
    float decrease_enemy_rate_time;

    // Start is called before the first frame update
    void Start()
    {
        spawn_rate_time = 0;
        decrease_enemy_rate_time = 0;
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
                Instantiate(common_enemy_1, new Vector2(player.transform.position.x + camera_x_offset, 
                    player.transform.position.y + camera_y_offset), Quaternion.identity);
                number_of_enemies++;
                spawn_rate_time = 0;
            }
        }

        decrease_enemy_rate_time += Time.deltaTime * 100;
        if (decrease_enemy_rate_time > decrease_enemy_rate)
        {
            number_of_enemies--;
            decrease_enemy_rate_time = 0;
        }
    }
}
