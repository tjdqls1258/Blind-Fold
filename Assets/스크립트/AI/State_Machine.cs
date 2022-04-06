using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AI_State
{
    Start_State = -1,
    Idle_State,
    Seek_Player,
    Seek_Echo,
    Pat_State,
    End_State
};

public class State_Machine : MonoBehaviour
{
    IState This_State;
    public AI_State aI_State = AI_State.Idle_State;

    public void Run_State()
    {
        This_State.Excute();
    }

    public void Change_State(IState state)
    {
        if(This_State == null)
        {
            This_State = state;
            aI_State = This_State.Get_State();
            return;
        }
        This_State.End_State();
        This_State = state;
        aI_State = This_State.Get_State();
        This_State.Start_State();
    }
}
