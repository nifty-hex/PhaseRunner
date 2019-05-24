using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_shoot : MonoBehaviour
{

    //public GameObject player;
    public GameObject bulletPrefab;
    public float fireRate = 0.5f;
    public int gunType = 0;
    public int ammoCount; //-1 = infinite bullets
    private float nextFire;
    private int totalBulletTypes = 4; //assume at least 2
    private int[] ammo;
    // Use this for initialization
    void Start()
    {
        //        transform.position = player.transform.position;
        //transform.position += new Vector3(1f, 0, 0);
        nextFire = fireRate;
        ammo = new int[totalBulletTypes];
        for (int i = 1; i < totalBulletTypes; i++)
            ammo[i] = ammoCount;
        ammo[0] = -1;
    }

    // Update is called once per frame
    void Update()
    {
        //       transform.position = player.transform.position;
        //transform.position += new Vector3(1f, 0, 0);
        faceMouse();
        nextFire += Time.deltaTime;
        changeGun();
        shootGun();
        if (ammo[gunType] == 0)
            gunType = 0;
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
    void shootGun()
    {
        switch (gunType)
        {
            case 0:
                regularGun();
                break;
            case 1:
                machineGun();
                break;
            case 2:
                shotGun();
                break;
            case 3:
                homingGun();
                break;
            /*case 4:
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
        if (ammo[gunType] == 0)
            gunType = 0;
    }
    void changeGun()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            gunType = 0;
        if (Input.GetKeyDown(KeyCode.Alpha4) && ammo[3] != 0)
            gunType = 3;
        if (Input.GetKeyDown(KeyCode.Alpha3) && ammo[2] != 0)
            gunType = 2;
        if (Input.GetKeyDown(KeyCode.Alpha2) && ammo[1] != 0)
            gunType = 1;
        //Debug.Log("Changing type");
    }
    void regularGun()
    {
        if (Input.GetMouseButton(0) && nextFire >= fireRate)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            nextFire = 0;
        }
    }
    void machineGun()
    {
        float fasterFireRate = fireRate / 2;
        if (Input.GetMouseButton(0) && nextFire >= fasterFireRate && ammo[gunType] != 0)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            nextFire = 0;
            if (ammo[gunType] != -1)
                ammo[gunType]--;
        }
    }
    void shotGun()
    {
        float shootAngle = 30; //total angle between 2 end bullets
        int bulletCount = 3; //minimum 2
        if (Input.GetMouseButton(0) && nextFire >= fireRate && ammo[gunType] != 0)
        {
            int b = bulletCount;
            if (b > ammo[gunType] && ammo[gunType] != -1)
                b = ammo[gunType];
            for (int a = 0; a < b; a++)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                if (b != 1)
                    bullet.GetComponent<Rigidbody2D>().rotation += -shootAngle/2 + shootAngle * a / (b-1);
            }
            nextFire = 0;
            if (ammo[gunType] != -1)
                ammo[gunType] -= b;
        }
    }
    void homingGun()
    {
        if (Input.GetMouseButton(0) && nextFire >= fireRate && ammo[gunType] != 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.bulletType = 1;
            nextFire = 0;
            if (ammo[gunType] != -1)
                ammo[gunType]--;
        }
    }
}