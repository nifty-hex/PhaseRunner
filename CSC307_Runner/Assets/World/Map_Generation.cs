using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Generation : MonoBehaviour {

    public float player_x_pos = 0;
    public float player_starting_x_offset;
    public float player_x_offset;
    public float map_x_gap; //21-25
    public float map_x_offset;
    public float map_y_pos; //0-4
    public float map_y_offset;

    public int obstacles_freq;
    public float obstacles_x_offset_min;
    public float obstacles_x_offset_max;
    public float obstacles_y_offset;

    public GameObject Platform_1;
    public GameObject Platform_2;
    
    public GameObject Window_1;
    public GameObject Window_2;

    public GameObject Med_1;
    public GameObject Long_1;

    public GameObject Banner_Big; //1
    public GameObject Banner_Coke; //2
    public GameObject Banner_Neon; //3
    public GameObject Banner_Scroll; //4
    public GameObject Banner_Side; //5
    public GameObject Banner_Sushi; //6
    public GameObject Banner_Arrow; //7
    public GameObject Banner_Open; //8
    public GameObject Banner_Small; //9
    public GameObject Banners; //10
    public GameObject Hotel_Sign; //11
    public float banner_x_offset;
    public float banner_y_offset;
    int banner_id;

    public GameObject obstacle_1;
    public GameObject obstacle_2;
    public GameObject Enemy_1;

    public int map_id;
    float med_scale;
    float long_scale;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        //Platforms
		if (transform.position.x + player_x_offset > player_x_pos && transform.position.x > player_starting_x_offset)
        {
            map_id = Random.Range(0, 6);
            map_x_gap = Random.Range(20.5f, 24.5f);
            map_y_pos = Random.Range(0f, 3.1f);
            

            if (map_id == 6)
            {
                player_x_pos += map_x_gap * med_scale;
            }
            else if (map_id == 7)
            {
                player_x_pos += map_x_gap * long_scale;
            }
            else
            {
                player_x_pos += map_x_gap;
            }

            if (map_id >= 0 && map_id <= 4)
            {
                //Spawning Normal Buildings
                if (Random.Range(0,2) == 0)
                    Instantiate(Platform_1, new Vector3(player_x_pos + map_x_offset, map_y_pos + map_y_offset, 0), Quaternion.identity);
                else
                    Instantiate(Platform_2, new Vector3(player_x_pos + map_x_offset, map_y_pos + map_y_offset, 0), Quaternion.identity);
            }
            else if (map_id == 5)
            {
                //Spawning Window Buildings
                Instantiate(Window_1, new Vector3(player_x_pos + map_x_offset, map_y_pos + map_y_offset, 0), Quaternion.identity);
            }
            else if (map_id == 6)
            {
                print("Spawning Med Building");
                Instantiate(Med_1, new Vector3(player_x_pos + map_x_offset * med_scale, map_y_pos + map_y_offset, 0), Quaternion.identity);
            }
            else if (map_id == 7)
            {
                Instantiate(Long_1, new Vector3(player_x_pos + map_x_offset * long_scale, map_y_pos + map_y_offset, 0), Quaternion.identity);
            }

            //Spawning Banners
            banner_id = Random.Range(1, 12);
            if (map_id < 6)
            {
                if (banner_id == 1)
                {
                    Instantiate(Banner_Big, new Vector3(player_x_pos + map_x_offset + banner_x_offset,
                        map_y_pos + map_y_offset + banner_y_offset, -2), Quaternion.identity);
                }
                else if (banner_id == 2)
                {
                    Instantiate(Banner_Coke, new Vector3(player_x_pos + map_x_offset + banner_x_offset,
                        map_y_pos + map_y_offset + banner_y_offset, -2), Quaternion.identity);
                }
                else if (banner_id == 3)
                {
                    Instantiate(Banner_Neon, new Vector3(player_x_pos + map_x_offset + banner_x_offset,
                        map_y_pos + map_y_offset + banner_y_offset, -2), Quaternion.identity);
                }
                else if (banner_id == 4)
                {
                    Instantiate(Banner_Scroll, new Vector3(player_x_pos + map_x_offset + banner_x_offset,
                        map_y_pos + map_y_offset + banner_y_offset, -2), Quaternion.identity);
                }
                else if (banner_id == 5)
                {
                    Instantiate(Banner_Side, new Vector3(player_x_pos + map_x_offset + banner_x_offset,
                        map_y_pos + map_y_offset + banner_y_offset, -2), Quaternion.identity);
                }
                else if (banner_id == 6)
                {
                    Instantiate(Banner_Sushi, new Vector3(player_x_pos + map_x_offset + banner_x_offset,
                        map_y_pos + map_y_offset + banner_y_offset, -2), Quaternion.identity);
                }
                else if (banner_id == 7)
                {
                    Instantiate(Banner_Arrow, new Vector3(player_x_pos + map_x_offset + banner_x_offset,
                        map_y_pos + map_y_offset + banner_y_offset, -2), Quaternion.identity);
                }
                else if (banner_id == 8)
                {
                    Instantiate(Banner_Open, new Vector3(player_x_pos + map_x_offset + banner_x_offset,
                        map_y_pos + map_y_offset + banner_y_offset, -2), Quaternion.identity);
                }
                else if (banner_id == 9)
                {
                    Instantiate(Banner_Small, new Vector3(player_x_pos + map_x_offset + banner_x_offset,
                        map_y_pos + map_y_offset + banner_y_offset, -2), Quaternion.identity);
                }
                else if (banner_id == 10)
                {
                    Instantiate(Banners, new Vector3(player_x_pos + map_x_offset + banner_x_offset,
                        map_y_pos + map_y_offset + banner_y_offset, -2), Quaternion.identity);
                }
                else if (banner_id == 11)
                {
                    Instantiate(Hotel_Sign, new Vector3(player_x_pos + map_x_offset + banner_x_offset,
                        map_y_pos + map_y_offset + banner_y_offset, -2), Quaternion.identity);
                }
            }

            if (map_id == 6)
            {
                player_x_pos += map_x_gap * 1;
            }
        }

        //Obstacles
        if (Random.Range(0, obstacles_freq) == 0)
        {
            Instantiate(obstacle_1, new Vector3(transform.position.x + Random.Range(obstacles_x_offset_min, obstacles_x_offset_max), 
                map_y_pos + obstacles_y_offset, 0), Quaternion.identity);
        }

    }
}
