using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_IdleState : IState
{
    public void Start_State(){}
    public void Excute() {  }
    public void End_State()  {   }
    public AI_State Get_State()
    {
        return AI_State.Idle_State;
    }
}
