using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimation_Toan : MonoBehaviour
{
    public GameObject Wall_Explosion;
    public float explod_rate = 0.1f;

    // Update is called once per frame
    private void Start()
    {
        StartCoroutine(spawnExplosion());
    }

    IEnumerator spawnExplosion()
    {
        while (true) // while game not over
        {
            yield return new WaitForSeconds(explod_rate);
            Instantiate(Wall_Explosion, transform.position, transform.rotation);
            Instantiate(Wall_Explosion, new Vector3(transform.position.x + 
                Random.Range(0f,2f), transform.position.y + Random.Range(-4f,4f), transform.position.z), transform.rotation) ;
        }
        
    }
}
