using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class I_SeekSound : IState
{
    NavMeshAgent navMesh = null;
    Vector3 Target_Point;
    GameObject State_AI;
    Animator Walk_Ain;
    float time = 0;
    NavMeshHit hit;

    bool Is_Arrive = false;
    public I_SeekSound(Vector3 target, GameObject AI)
    {
        Is_Arrive = false;
        State_AI = AI;
        navMesh = AI.GetComponent<NavMeshAgent>();
        Target_Point = target;
        Walk_Ain = AI.GetComponent<Animator>();
    }

    public void Start_State()
    {
        navMesh.destination = Target_Point;
        navMesh.isStopped = false;
        Walk_Ain.SetBool("Is_Walk", true);
    }

    public void Excute()
    {
        navMesh.SetDestination(Target_Point);
        if (navMesh.velocity == Vector3.zero && !Is_Arrive)
        {
            Is_Arrive = true;
            Serch_Around();
        }
    }

    public void End_State()
    {
        navMesh.ResetPath();
        navMesh.isStopped = true;
        Walk_Ain.SetBool("Is_Walk", false);
    }

    private void Serch_Around()//주위를 탐색함
    {
        State_AI.GetComponent<EnemyAI>().Repeating_Patrol(1.5f);
    }

    public AI_State Get_State()
    { 
        return AI_State.Seek_Echo;
    }
}
