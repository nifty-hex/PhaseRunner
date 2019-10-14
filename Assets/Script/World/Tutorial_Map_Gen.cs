using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Map_Gen : MonoBehaviour
{
    private PauseGame pausegame;
    public float player_x_pos = 0;
    public float player_starting_x_offset;
    public float player_x_offset;
    public float map_x_gap; //21-25
    public float map_x_offset;
    public float map_y_pos; //0-4
    public float map_y_offset;

    public GameObject Platform_1;

    public GameObject canvas;

    // Use this for initialization
    void Start()
    {
#if UNITY_STANDALONE || UNITY_WEBPLAYER
        canvas = GameObject.Find("CanvasMobile");
        if (canvas)
            canvas.SetActive(false);
#endif
        pausegame = GameObject.Find("SettingsBorder").GetComponent<PauseGame>();

        map_x_gap = 19f;
        map_y_pos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Platforms
        if (transform.position.x + player_x_offset > player_x_pos && transform.position.x > player_starting_x_offset)
        {
            Instantiate(Platform_1, new Vector3(player_x_pos + map_x_offset, map_y_pos + map_y_offset, 0), Quaternion.identity);

            player_x_pos += map_x_gap;

        }

        //Obstacles
        if (!pausegame.isPaused())
        {
            
        }
    }
}
