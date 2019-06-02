using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length + 0.02f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
