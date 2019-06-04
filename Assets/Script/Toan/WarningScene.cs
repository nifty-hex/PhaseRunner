//Owner: Toan Pham
//This script controls the scene Warning
//It will automatically load scene MainMenu if any button is press
//It also controls 2 rotating nuclear signs in the scene

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WarningScene : MonoBehaviour
{
    public GameObject nuclearSign; // reference to the nuclear sign sprite object
    GameObject instance1, instance2; //object instances to store the created object
    private void Start()
    {
        //spawn the nuclearSigns
        instance1 = Instantiate(nuclearSign, new Vector3(-5.96f, 3.04f, 0f), transform.rotation);
        instance2 = Instantiate(nuclearSign, new Vector3(5.96f, 3.04f, 0f), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        //rotate the nuclearSigns over time
        instance1.transform.Rotate(0, 0, Time.deltaTime*20);
        instance2.transform.Rotate(0, 0, Time.deltaTime*-20);
        //load MainMenu scene if any button is pressed
        if (Input.anyKey)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
