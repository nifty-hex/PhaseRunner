using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;


public class Player_shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject player;
    public GameObject flashSpawnPoint;
    public GameObject RailSpawnPoint;
    public GameObject playerFlash;
    public GameObject railbullet;
    public Animator animator;
    private AudioManager audiomanager;
    private InputManager inputmanager;
    private float fireRate = 0.5f;
    public int gunType;
    private int ammoCount;
    private float nextFire;
    public int[] ammo;
    private int totalBulletTypes = 4;
    private bool laserOn;

    void Start()
    {
        nextFire = fireRate;
        ammo = new int[totalBulletTypes];
        ammo[0] = -1;
        ammo[1] = 120; //machine gun
        ammo[2] = 30; //shotgun
        ammo[3] = 10; //railgun
        gunType = 0;
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        inputmanager = GameObject.Find("InputManager").GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        faceMouse();
        nextFire += Time.deltaTime;
        changeGun();
        shootGun();
        if (ammo[gunType] == 0)
        {
            animator.SetInteger("Gun", 0);
            gunType = 0;
        }
    }

    void faceMouse()
    {
#if UNITY_IOS || UNITY_ANDROID
        var mouseWorldPos = inputmanager.GetInputPosition();
#else
        var mousePos = Input.mousePosition;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;
#endif
        Vector3 difference = mouseWorldPos - transform.position;
        difference.Normalize();
        float rot = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot);
    }

    void changeGun()
    {
        int temp = inputmanager.switchGun();
        if (temp != -1)
        {
            audiomanager.Play("Gun_Change");
            gunType = temp;
        }

        if (gunType == 0)
        {
            animator.SetInteger("Gun", 0);
        }
        else if (gunType == 1 && ammo[1] != 0)
        {
            animator.SetInteger("Gun", 1);
        }
        else if (gunType == 2 && ammo[2] != 0)
        {
            animator.SetInteger("Gun", 2);
        }
        else if (gunType == 3 && ammo[3] != 0)
        {
            animator.SetInteger("Gun", 3);
        }
        else
        {
            Debug.Log("changeGun error");
        }
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
                laserGun();
                break;
            default:
                Debug.Log("shootGun error");
                break;
        }
    }

    void regularGun()
    {
        if (inputmanager.Fire() && nextFire >= fireRate)
        {
            audiomanager.Play("Gun_Pistol");
            flashSpawnPoint.transform.localPosition = new Vector3(0.53f, 0.02f, 0f);
            Instantiate(playerFlash, flashSpawnPoint.transform.position, flashSpawnPoint.transform.rotation, flashSpawnPoint.transform);
            GameObject bullet = Instantiate(bulletPrefab, flashSpawnPoint.transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, 0);
            nextFire = 0;
        }
    }
    void machineGun()
    {
        float fasterFireRate = fireRate / 2;
        if (inputmanager.Fire() && nextFire >= fasterFireRate && ammo[gunType] != 0)
        {
            audiomanager.Play("Gun_Machine");
            flashSpawnPoint.transform.localPosition = new Vector3(0.82f, 0.06f, 0f);
            Instantiate(playerFlash, flashSpawnPoint.transform.position, flashSpawnPoint.transform.rotation, flashSpawnPoint.transform);
            GameObject bullet = Instantiate(bulletPrefab, flashSpawnPoint.transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, 0);
            nextFire = 0;
            if (ammo[gunType] != -1)
                ammo[gunType]--;
        }
    }
    void shotGun()
    {
        float shootAngle = 30; //total angle between 2 end bullets
        int bulletCount = 3; //minimum 2
        if (inputmanager.Fire() && nextFire >= fireRate && ammo[gunType] != 0)
        {
            audiomanager.Play("Gun_Shotgun");
            flashSpawnPoint.transform.localPosition = new Vector3(0.95f, 0.05f, 0f);
            Instantiate(playerFlash, flashSpawnPoint.transform.position, flashSpawnPoint.transform.rotation, flashSpawnPoint.transform);
            for (int a = 0; a < bulletCount; a++)
            {
                GameObject bullet = Instantiate(bulletPrefab, flashSpawnPoint.transform.position, transform.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, 0);
                bullet.transform.Rotate(0, 0, -shootAngle / 2 + shootAngle * a / (bulletCount - 1));
            }
            nextFire = 0;
            if (ammo[gunType] != -1)
                ammo[gunType] -= 1;
        }
    }
   
    void laserGun()
    {
        if (inputmanager.Fire() && nextFire >= fireRate && ammo[gunType] != 0)
        {
            flashSpawnPoint.transform.localPosition = new Vector3(0.96f, 0.05f, 0f);
            Instantiate(playerFlash, flashSpawnPoint.transform.position, flashSpawnPoint.transform.rotation, flashSpawnPoint.transform);
            Instantiate(railbullet, RailSpawnPoint.transform.position, RailSpawnPoint.transform.rotation);
            nextFire = 0;
            if (ammo[gunType] != -1)
                ammo[gunType]--;

        }
    }

    public int maxAmmo(int gunType)
    {
        int max = 0;
        switch (gunType)
        {
            case 0:
                max = -1;
                break;
            case 1:
                max = 200;
                break;
            case 2:
                max = 50;
                break;
            case 3:
                max = 15;
                break;
            default:
                Debug.Log("maxAmmo error");
                break;
        }

        return max;
    }

    /*void homingGun()
   {
       if (WrapInput.Fire() && nextFire >= fireRate && ammo[gunType] != 0)
       {
           GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
           bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, 0);
           Bullet bulletScript = bullet.GetComponent<Bullet>();
           bulletScript.bulletType = 1;
           nextFire = 0;
           if (ammo[gunType] != -1)
               ammo[gunType]--;
       }
   }*/
}