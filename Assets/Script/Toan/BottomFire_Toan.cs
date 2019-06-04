//Owner: Toan Pham
//This script will take care of the behavior of the fire sprite prefab

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomFire_Toan : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        // set different animations for fire prefab when it s spawned
        // there are 4 different fire animations to this prefab in its animator
        animator.SetInteger("FireNumber", Random.Range(1, 4)); 
    }
}
