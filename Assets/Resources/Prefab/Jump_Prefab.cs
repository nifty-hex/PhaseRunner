using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Prefab : MonoBehaviour
{

    public bool can_jump;
    public bool can_double_jump;
    public float jump_force;
    public float double_jump_force;
    private Rigidbody2D rigidBody;

    public bool did_jump;
    public bool did_double_jump;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        jump_force = 10f;
        double_jump_force = jump_force;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void jump()
    {
        Debug.Log("Single Jump");
        float y = transform.position.y;
        gameObject.transform.position = new Vector2(transform.position.x, y += jump_force);
        did_jump = true;
    }

    public void double_jump()
    {
        Debug.Log("Double Jump");
        float y = transform.position.y;
        gameObject.transform.position = new Vector2(transform.position.x, y += double_jump_force);
        did_double_jump = true;
    }
}
