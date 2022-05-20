using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_AttackState : IState
{
    Animator AI_Atk_Ain;

    public I_AttackState(GameObject self)
    {
        AI_Atk_Ain = self.GetComponent<Animator>();
    }

    public void Start_State() 
    {
        AI_Atk_Ain.SetBool("Is_Atk", true);
    }

    public void Excute() 
    {
        //공격 처리
    }

    public void End_State() 
    {
        AI_Atk_Ain.SetBool("Is_Atk", false);
    }

    public AI_State Get_State()
    {
        return AI_State.Atk_State;
    }
}
