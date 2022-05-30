using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4_03 : MonoBehaviour
{
    private Animator animator;
    private bool Is_Coll = false;
    //[SerializeField] GameObject Hands;

    private void Awake()
    {
        animator = GetComponent<Animator>();    
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !Is_Coll)
        {
            animator.SetBool("Is_Coll", true);
        }
    }
}
