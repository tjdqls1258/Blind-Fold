using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class I_IdleState : IState
{
    Vector3 First_Pos, First_Rotate;
    GameObject Self;
    NavMeshAgent navMesh;
    Animator Walk_Ain;
    bool Is_Arrive = false;

    public I_IdleState(GameObject AI,Vector3 Pos, Vector3 rotate)
    {
        navMesh = AI.GetComponent<NavMeshAgent>();
        Self = AI;
        First_Pos = Pos;
        First_Rotate = rotate;
        Walk_Ain = AI.GetComponent<Animator>();
    }
    
    public void Start_State()
    {
        Is_Arrive = false;
        navMesh.destination = First_Pos;
        navMesh.isStopped = false;
        Walk_Ain.SetBool("Is_Walk", true);
    }

    public void Excute() 
    {
        if (navMesh.velocity == Vector3.zero && !Is_Arrive)
        {
            if (Vector3.SqrMagnitude(Self.transform.rotation.eulerAngles - First_Rotate) >= 0.5f)
            {
                Self.transform.Rotate(First_Rotate, 0.1f);
            }
            else
            {
                Is_Arrive = true;
                Walk_Ain.SetBool("Is_Walk", false);
            }
            
        }
    }

    public void End_State() 
    {
        navMesh.ResetPath();
        navMesh.isStopped = true;
        Walk_Ain.SetBool("Is_Walk", false);
    }

    public AI_State Get_State()
    {
        return AI_State.Idle_State;
    }
}
