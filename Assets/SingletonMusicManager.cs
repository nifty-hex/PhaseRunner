using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMusicManager : MonoBehaviour
{
    public static SingletonMusicManager i;

    void Awake()
    {
        if (i == null)
        {
            i = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(this); // or gameObject
    }
}
