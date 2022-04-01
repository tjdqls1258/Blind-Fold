using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Move : MonoBehaviour
{
    [SerializeField] private float Run_Speed = 1.5f;
    [SerializeField] private float Move_Speed = 5;
    [SerializeField] private float Max_Stamina_Gage = 5.0f;
    [SerializeField] private float Min_Stamina_Gage = 1.0f;
    [SerializeField] private float Stamina_Gage = 5.0f;

    private float Is_Run_Speed = 1.0f;
    private bool IsRun = false;

    [SerializeField] private Image Stamina_Image;
    private Rigidbody rigid;
    private Relay_Sound relay;
    private Animator foot;
    
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        relay = GetComponent<Relay_Sound>();
        foot = GameObject.Find("Foot").GetComponent<Animator>();
    }

    private void Update()
    {
        Is_Run();
        move();
    }

    private void move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 dirset = Vector3.right * horizontal + Vector3.forward * vertical;

        dirset = Camera.main.transform.TransformDirection(dirset);
        dirset.Normalize(); //방향 구함. 
        dirset.y = 0;
        rigid.MovePosition(transform.position + dirset * (Move_Speed*Is_Run_Speed) * Time.deltaTime);

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

    private void Is_Run()
    {
        Is_Run_Speed = 1.0f;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Stamina_Gage >= Min_Stamina_Gage)
            {
                IsRun = true;
            }

            if (IsRun && (Stamina_Gage >= 0.01f))
            {
                Is_Run_Speed = Run_Speed;
                Stamina_Gage -= Time.deltaTime;
            }
            else
            {
                IsRun = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            IsRun = false;
        }

        if (Stamina_Gage <= Max_Stamina_Gage && !IsRun)
        {
            Stamina_Gage += Time.deltaTime;
        }
        Stamina_Image.fillAmount = Stamina_Gage / Max_Stamina_Gage;
    }
}