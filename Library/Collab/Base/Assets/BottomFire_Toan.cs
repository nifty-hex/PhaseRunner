using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomFire_Toan : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetInteger("FireNumber", Random.Range(1, 4));
    }
}
