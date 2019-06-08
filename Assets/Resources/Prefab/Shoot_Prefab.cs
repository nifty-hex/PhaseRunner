using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Prefab : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bullet;

    void Start()
    {
        bullet = Resources.Load<GameObject>("Prefab/Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject createBullet()
    {
        GameObject created_bullet =
            Instantiate(bullet, transform.position, Quaternion.identity);
        return created_bullet;
    }
}
