using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AimMouse : MonoBehaviour
{
    public GameObject player;
    public GameObject bulletPrefab;
    public float fireRate = 0.5f;

    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.transform.position;
        transform.position += new Vector3(0.5f, 0, 0);
        nextFire = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        transform.position += new Vector3(0.5f, 0, 0);
        faceMouse();
        nextFire += Time.deltaTime;
        if (Input.GetMouseButton(0) && nextFire >= fireRate)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            nextFire = 0;
        }
    }

    void faceMouse()
    {
        //Vector3 mouseWorldPos = camera.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Vector3 mousWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Set the rotation of the sprite so it always faces the player
        Vector2 relPos = new Vector2(transform.position.x - mousWorldPos.x,
            transform.position.y - mousWorldPos.y); // Get the relative position from player to this object

        transform.right = -relPos; // Change the direction of right to be the relative position's x and y coordinates
    }


}