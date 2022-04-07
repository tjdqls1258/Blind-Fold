using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullte_Move : MonoBehaviour
{
    [SerializeField] float Throwing_Power_X = 1500.0f;
    [SerializeField] float Throwing_Power_Y = 1000.0f;
    Rigidbody rigid;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        Rock_Throwing();
    }

    public void Rock_Throwing()
    {
        rigid.AddForce((transform.forward * Throwing_Power_X) + (transform.up * Throwing_Power_Y));
    }
}