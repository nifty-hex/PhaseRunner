using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimationDestroy_Toan : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length + 0.07f);
    }
}
