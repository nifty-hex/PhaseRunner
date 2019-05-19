using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimation_Toan : MonoBehaviour
{
    public GameObject Wall_Explosion;


    // Update is called once per frame
    private void Start()
    {
        StartCoroutine(spawnExplosion());
    }

    IEnumerator spawnExplosion()
    {
        while (true) // while game not over
        {
            yield return new WaitForSeconds(0.3f);
            Instantiate(Wall_Explosion, transform.position, transform.rotation);
            Instantiate(Wall_Explosion, new Vector3(transform.position.x + 
                Random.Range(0f,2f), transform.position.y + Random.Range(-2.5f,2.5f), transform.position.z), transform.rotation) ;
        }
        
    }
}
