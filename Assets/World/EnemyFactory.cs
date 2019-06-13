using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public float camera_x_offset;
    public float camera_y_offset;

    public GameObject player;
    
    int enemy_id;
    public GameObject common_enemy_1; //Drones
    public GameObject common_enemy_2; //Charger
    public GameObject common_enemy_3; //Boomer

    public void buildEnemy(int enemy_id)
    {
	if (enemy_id == 0 || enemy_id == 2 || enemy_id == 6 )
	{
	    Instantiate(common_enemy_1, new Vector2(player.transform.position.x + camera_x_offset,
		player.transform.position.y + camera_y_offset-10), Quaternion.identity);
	}
	else if (enemy_id == 1 || enemy_id == 3 || enemy_id == 5 || enemy_id == 7)
	{
	    Instantiate(common_enemy_2, new Vector2(player.transform.position.x + camera_x_offset+45,
		player.transform.position.y + camera_y_offset+40), Quaternion.identity);
	}
	else if ( enemy_id == 4 || enemy_id == 8 )
	{
	    Instantiate(common_enemy_3, new Vector2(player.transform.position.x + camera_x_offset + 30,
		player.transform.position.y + camera_y_offset + 90), Quaternion.identity);
	}

    }    
}
