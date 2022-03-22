using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Machine : MonoBehaviour
{
    IState This_State;

    public void Run_State()
    {
        This_State.Excute();
    }

    public void Change_State(IState state)
    {
        if(This_State == null)
        {
            This_State = state;
            return;
        }
        This_State.End_State();
        This_State = state;
        This_State.Start_State();
    }
}
