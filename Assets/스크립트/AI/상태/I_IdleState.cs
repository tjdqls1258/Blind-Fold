using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_IdleState : MonoBehaviour, IState
{
    Vector3 First_Pos, First_Rotate;
    public I_IdleState(Vector3 transform, Vector3 rotate)
    {
        First_Pos = transform;
    }
    public void Start_State(){}
    public void Excute() 
    {
        if (First_Pos == null || First_Rotate == null)
        {
            return;
        }
        if (Vector3.SqrMagnitude(gameObject.transform.position - First_Pos) <= 1.0f &&
            Vector3.SqrMagnitude(gameObject.transform.rotation.eulerAngles - First_Rotate) >= 0.1f)
        {
            gameObject.transform.Rotate(First_Rotate, 10);
        }
    }
    public void End_State()  {   }
    public AI_State Get_State()
    {
        return AI_State.Idle_State;
    }
}
