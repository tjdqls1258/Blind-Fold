using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_InterPlay : MonoBehaviour, I_Interplay_effect
{
    Animator animator;
    bool It_Close = true;
    private void Awake()
    {
        //해당 컴포넌트를 Interplay_machice에 참조시킨다.
        animator = GetComponent<Animator>();
        GetComponent<Interplay_machice>().SetInterplay(this);
    }

    public void Effect()
    {
        animator.SetBool("SwitchDoor", It_Close);
        if (It_Close)
        {
            GetComponent<Interplay_machice>().Exposition = "문 열기";
        }
        else
        {
            GetComponent<Interplay_machice>().Exposition = "문 닫기";
        }
        It_Close = !It_Close;
    }
}
