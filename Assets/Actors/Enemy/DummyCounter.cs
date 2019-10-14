using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DummyCounter : MonoBehaviour
{
    public int num_of_enemy = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (num_of_enemy <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
