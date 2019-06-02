using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Smooth_Camera : MonoBehaviour {

    public Transform target;
    public Rigidbody2D rb;
    public float smoothSpeed;
    public Vector3 offset;

    private Rigidbody2D rigidBody;

    void FixedUpdate()
    {
        Application.targetFrameRate = 60;
        if (Input.GetKey("q"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
