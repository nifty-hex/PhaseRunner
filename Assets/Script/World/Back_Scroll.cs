using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_Scroll : MonoBehaviour {

    public float speed;
    Vector3 startPos;
    public float x_position, y_position;
    public float x_gap;
    public float y_offset;

    public Transform cam;
    public float cam_x_offset;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(x_position, y_position) * speed * Time.deltaTime);
        if (transform.position.x < x_gap + cam.transform.position.x)
        {
            startPos.x += cam.transform.position.x;
            transform.position = new Vector3(cam.transform.position.x + cam_x_offset, y_offset,transform.position.z);
        }

    }
}

