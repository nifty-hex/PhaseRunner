//Owner: Toan Pham
//This script handles the behavior of the gun flash sprite animation

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashScript : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        //destroy the sprite after a specific amount of time
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length + 0.01f);
    }

}
