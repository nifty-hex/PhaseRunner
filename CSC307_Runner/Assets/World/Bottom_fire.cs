using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottom_fire : MonoBehaviour {

    public Transform player;
    public float y_offset;
    public float z_offset;

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
            Debug.Log("Game Over");
        }
    }
}
