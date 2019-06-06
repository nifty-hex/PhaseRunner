using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonSoundManager : MonoBehaviour
{
    public static SingletonSoundManager i;

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
