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

    public I_SeekSound(Transform target, GameObject AI)
    {
        State_AI = AI;
        Target_Point = new Vector3(target.position.x, AI.transform.position.y, target.position.z);
        navMesh = AI.GetComponent<NavMeshAgent>();
        Walk_Ain = AI.GetComponent<Animator>();
    }

    public void Start_State()
    {
        navMesh.isStopped = false;
        navMesh.destination = Target_Point;
        Walk_Ain.SetBool("Is_Walk", true);
    }

    public void Excute()
    { 
        if (navMesh.velocity == Vector3.zero)
        {
            Serch_Around();
        }
    }

    public void End_State()
    {
        navMesh.isStopped = true;
        Walk_Ain.SetBool("Is_Walk", false);
    }

    private void Serch_Around()//주위를 탐색함
    {
        State_AI.GetComponent<EnemyAI>().Repeating_Patrol();
        Debug.Log("Enemy Patrol");
    }

    public AI_State Get_State()
    { 
        return AI_State.Seek_Echo;
    }
}
