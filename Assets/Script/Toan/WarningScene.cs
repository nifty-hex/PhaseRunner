using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WarningScene : MonoBehaviour
{
    public GameObject nuclearSign;
    GameObject instance1, instance2;
    private void Start()
    {
        instance1 = Instantiate(nuclearSign, new Vector3(-5.96f, 3.04f, 0f), transform.rotation);
        instance2 = Instantiate(nuclearSign, new Vector3(5.96f, 3.04f, 0f), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        instance1.transform.Rotate(0, 0, Time.deltaTime*10);
        instance2.transform.Rotate(0, 0, Time.deltaTime*-10);
        if (Input.anyKey)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
