using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_shoot : MonoBehaviour
{

    //   public GameObject player;
    public GameObject bulletPrefab;
    public float fireRate = 0.5f;
    public int gunType = 0;
    private float nextFire;

    // Use this for initialization
    void Start()
    {
        //        transform.position = player.transform.position;
        //transform.position += new Vector3(1f, 0, 0);
        nextFire = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        //       transform.position = player.transform.position;
        //transform.position += new Vector3(1f, 0, 0);
        faceMouse();
        nextFire += Time.deltaTime;
        switch (gunType)
        {
            case 0:
                if (Input.GetMouseButton(0) && nextFire >= fireRate)
                {
                    Instantiate(bulletPrefab, transform.position, transform.rotation);
                    nextFire = 0;
                }
                break;
            case 1:
                if (Input.GetMouseButton(0) && nextFire >= fireRate / 4)
                {
                    Instantiate(bulletPrefab, transform.position, transform.rotation);
                    nextFire = 0;
                }
                break;
            case 2:
                if (Input.GetMouseButton(0) && nextFire >= fireRate)
                {
                    float shootAngle = 30;
                    for (int a = 0; a < 5; a++)
                    {
                        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                        bullet.GetComponent<Rigidbody2D>().rotation += -shootAngle + 2 * shootAngle * a / 4;
                    }
                    nextFire = 0;
                }
                break;
            /*case 3:
                if (Input.GetMouseButton(0) && nextFire >= fireRate)
                {
                    GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                    Bullet_Script bulletScript = bullet.GetComponent<Bullet_Script>();
                    bulletScript.bulletType = 1;
                    //bull.transform.localScale = new Vector3(5f, 5f, bull.transform.localScale.z);
                    nextFire = 0;
                }
                break;
            case 4:
                if (Input.GetMouseButton(0) && nextFire >= fireRate)
                {
                    GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                    Bullet_Script bulletScript = bullet.GetComponent<Bullet_Script>();
                    bulletScript.bulletType = 2;
                    //bull.transform.localScale = new Vector3(10f, 10f, bull.transform.localScale.z);
                    nextFire = 0;
                }
                break;*/
            default:
                Debug.Log("Default bullet");
                break;
        }

    }

    void faceMouse()
    {
        //Vector3 mouseWorldPos = camera.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        var mousePos = Input.mousePosition;
        mousePos.z = 12;
        Vector3 mousWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        //Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);        //Set the rotation of the sprite so it always faces the player
        //Vector3 vector = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 difference = mousWorldPos - transform.position;
        difference.Normalize();
        float rot = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot);
        //    mousePos.y - transform.position.y); // Get the relative position from player to this object

        //transform.right = relPos; // Change the direction of right to be the relative position's x and y coordinates

    }
}