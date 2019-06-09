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
    public GameObject common_enemy_1; //Drones
    public GameObject common_enemy_2; //Charger
    public GameObject common_enemy_3; //Boomer


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
                enemy_id = Random.Range(0, spawn_type); //max = 8, starts at 2
                if (enemy_id == 0 || enemy_id == 3 || enemy_id == 6 )
                {
                    Instantiate(common_enemy_1, new Vector2(player.transform.position.x + camera_x_offset,
                        player.transform.position.y + camera_y_offset-10), Quaternion.identity);
                }
                else if (enemy_id == 1 || enemy_id == 2 || enemy_id == 5 || enemy_id == 7) 
                {
                    Instantiate(common_enemy_2, new Vector2(player.transform.position.x + camera_x_offset+45,
                        player.transform.position.y + camera_y_offset+40), Quaternion.identity);
                }
                else if ( enemy_id == 4 || enemy_id == 8 )
                {
                    Instantiate(common_enemy_3, new Vector2(player.transform.position.x + camera_x_offset + 30,
                        player.transform.position.y + camera_y_offset + 90), Quaternion.identity);
                }
                number_of_enemies++;
                spawn_rate_time = 0;
            }
        }
    }
}
