using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public float Move_Speed = 5;
    Rigidbody rigid;
    Relay_Sound relay;
    Animator foot;
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        relay = GetComponent<Relay_Sound>();
        foot = GameObject.Find("Foot").GetComponent<Animator>();
    }

    private void Update()
    {
        move();
    }

    private void move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 dirset = Vector3.right * horizontal + Vector3.forward * vertical;

        dirset = Camera.main.transform.TransformDirection(dirset);
        dirset.Normalize(); //���� ����. 
        dirset.y = 0;
        rigid.MovePosition(transform.position + dirset * Move_Speed * Time.deltaTime);

        if (foot != null)
        {
            if (horizontal + vertical == 0)
            {
                foot.Play(0);
            }
            else
            {
                foot.Play(1);
            }
        }

        if (rigid.velocity != Vector3.zero)
        {
            rigid.velocity = Vector3.zero;
        }
    }
}