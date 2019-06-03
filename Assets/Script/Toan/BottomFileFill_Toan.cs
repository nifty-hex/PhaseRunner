//Owner: Toan Pham
//This script will create multiple fire sprite objects to cover the bottomfire object

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomFileFill_Toan : MonoBehaviour
{
    public GameObject bottomfire; //reference to the fire sprite prefab
    public float x;
    void Start()
    {
        while (x < 120f)
        {
            GameObject newFire = Instantiate(bottomfire, new Vector3(x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(0f, 1.5f),
                transform.position.z), transform.rotation); // spawn a new fire a specific point,with random range for better effect
            newFire.transform.parent = gameObject.transform; //set the parent of the current fire sprite to be the bottomfire
            x += 1.2f; //move to the next point to generate
        }
    }
}
