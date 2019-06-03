// Owner: Toan Pham
// This script takes care of spawning explosion sprite prefab on the Wall object

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimation_Toan : MonoBehaviour
{
    public GameObject Wall_Explosion; // reference to the explosion prefab
    public float timeBetweenExplosion = 0.1f; 

    private void Start()
    {
        StartCoroutine(spawnExplosion()); // start coroutine to spawn sprite prefab
    }

    IEnumerator spawnExplosion()
    {
        while (true) // while game not over
        {
            yield return new WaitForSeconds(timeBetweenExplosion); // wait before specific seconds before spawning a sprite
            Instantiate(Wall_Explosion, new Vector3(transform.position.x + 
                Random.Range(0f,2f), transform.position.y + Random.Range(-5f,5f), transform.position.z), transform.rotation) ;
        }
        
    }
}
