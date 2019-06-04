//Owner: Toan Pham
//This script handles the behavior of the explosion sprite object

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimationDestroy_Toan : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        //destroy the explosion after specific amount of time
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length + 0.05f);
    }
}
