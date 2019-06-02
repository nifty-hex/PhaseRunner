using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottom_fire : MonoBehaviour {

    public Transform player;
    public float y_offset;
    public float z_offset;
    public Enemy_Spawn en_spawn;
    public Player_Health hp;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = new Vector3(player.position.x, y_offset, z_offset);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hp.health = 0;
        }
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Obstacles" ||
            collision.gameObject.tag == "Item_Pickup")
        {
            if (collision.gameObject.tag == "Enemy")
                en_spawn.number_of_enemies--;
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hp.health = 0;
        }
    }
}
