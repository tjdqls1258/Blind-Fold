using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public void Start_State();
    public void Excute();
    public void End_State();
    public AI_State Get_State();
}
