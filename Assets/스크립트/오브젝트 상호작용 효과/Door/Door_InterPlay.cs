using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_InterPlay : MonoBehaviour, I_Interplay_effect
{
    Animator animator;
    [SerializeField] bool It_Close = true;
    [SerializeField] bool Isclear = false;
    [SerializeField] int key_num;

    [SerializeField] GameObject Player;

    private void Awake()
    {
        //�ش� ������Ʈ�� Interplay_machice�� ������Ų��.
        animator = GetComponent<Animator>();
        GetComponent<Interplay_machice>().SetInterplay(this);
        animator.SetBool("SwitchDoor", It_Close);
        if (It_Close)
        {
            GetComponent<Interplay_machice>().Exposition = "�� ����";
        }
        else
        {
            GetComponent<Interplay_machice>().Exposition = "�� �ݱ�";
        }
    }

    public void Effect()
    {
        if (Player.GetComponent<Player_Move>().collect_key >= key_num)
        {
            animator.SetBool("SwitchDoor", It_Close);
            if (It_Close)
            {
                GetComponent<Interplay_machice>().Exposition = "�� ����";
            }
            else
            {
                GetComponent<Interplay_machice>().Exposition = "�� �ݱ�";
            }
            It_Close = !It_Close;

            if (Isclear)
            {
                this.GetComponent<ClearPoint>().Clear();
            }
        }
    }
}
