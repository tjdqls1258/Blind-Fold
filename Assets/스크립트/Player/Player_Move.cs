using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Move : MonoBehaviour
{
    [Header("이동 속도 관련")]
    [SerializeField] private float Run_Speed = 1.5f;
    [SerializeField] private float Move_Speed = 5;
    [Header("스테미나 관련")]
    [SerializeField] public float Max_Stamina_Gage = 5.0f;
    [SerializeField] private float Min_Stamina_Gage = 1.0f;
    [SerializeField] public float Stamina_Gage = 5.0f;

    [SerializeField] private Image Stamina_Image;

    private float Is_Run_Speed = 1.0f;
    private bool IsRun = false;

    [SerializeField] private AudioClip Hard_Run;

    private Rigidbody rigid;
    private Relay_Sound relay;
    private Animator animator;
    private AudioSource audioSource;
    public int collect_key;
    public bool stamina_pause = false;
    
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        relay = GetComponent<Relay_Sound>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        collect_key = 0;
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
        if(horizontal + vertical != 0 && (!audioSource.isPlaying))
        {
            audioSource.pitch = 1.5f;
            audioSource.Play();
        }
        if (rigid.velocity != Vector3.zero)
        {
            rigid.velocity = Vector3.zero;
        }
    }

    private void Is_Run()
    {
        Is_Run_Speed = 1.0f;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (Stamina_Gage >= Min_Stamina_Gage)
            {
                audioSource.Stop();
                IsRun = true;
            }
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (IsRun && (Stamina_Gage >= 0.01f))
            {
                audioSource.pitch = 2.5f;
                Is_Run_Speed = Run_Speed;
                animator.SetBool("Is_Run", true);
                Stamina_Gage -= Time.deltaTime;
            }
            else
            {
                animator.SetBool("Is_Run", false);
                if (Stamina_Gage <= 0.01f)
                {
                    audioSource.pitch = 1.0f;
                    audioSource.PlayOneShot(Hard_Run);
                }
                IsRun = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("Is_Run", false);
            IsRun = false;
        }

        if (Stamina_Gage <= Max_Stamina_Gage && !IsRun && !stamina_pause)
        {
            if (Stamina_Gage >= Max_Stamina_Gage)
            {
                Stamina_Gage = Max_Stamina_Gage;
            }
            else
            {
                Stamina_Gage += Time.deltaTime;
            }
        }

        Stamina_Image.fillAmount = Stamina_Gage / Max_Stamina_Gage;
    }

    public float get_stamina_percent()
    {
        return (Stamina_Gage/Max_Stamina_Gage);
    }
}