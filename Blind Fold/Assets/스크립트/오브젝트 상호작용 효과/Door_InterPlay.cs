using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_InterPlay : MonoBehaviour, I_Interplay_effect
{
    Animator animator;
    bool It_Close = true;
    private void Awake()
    {
        //�ش� ������Ʈ�� Interplay_machice�� ������Ų��.
        animator = GetComponent<Animator>();
        GetComponent<Interplay_machice>().SetInterplay(this);
    }

    public void Effect()
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
    }
}
