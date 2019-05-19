using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomFileFill_Toan : MonoBehaviour
{
    public GameObject bottomfire;
    public float x;
    // Start is called before the first frame update
    void Start()
    {
        while (x < 119f)
        {
            GameObject newFire = Instantiate(bottomfire, new Vector3(x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(0f, 1.5f),
                transform.position.z), transform.rotation);
            newFire.transform.parent = gameObject.transform;
            x += 1.2f;
        }
    }
}
