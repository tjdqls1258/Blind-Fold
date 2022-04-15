using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullte_Move : MonoBehaviour
{
    [SerializeField] float Throwing_Power_X = 1500.0f;
    [SerializeField] float Throwing_Power_Y = 1000.0f;
    Rigidbody rigid;

    private float Bullet_Charge;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        Bullet_Charge = GameObject.FindWithTag("Player").GetComponent<Fire_Bullte>().get_bullet_charge();
        Rock_Throwing();
    }

    public void Rock_Throwing()
    {
        rigid.AddForce((transform.forward * Throwing_Power_X * (Bullet_Charge / 2)) + (transform.up * Throwing_Power_Y));
    }
}