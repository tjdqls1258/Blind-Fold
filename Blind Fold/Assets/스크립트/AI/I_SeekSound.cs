using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class I_SeekSound : IState
{
    NavMeshAgent navMesh = null;
    Vector3 Target_Point;
    GameObject State_AI;

    public I_SeekSound(Vector3 transform, GameObject AI)
    {
        State_AI = AI;
        Target_Point = transform;
        navMesh = AI.GetComponent<NavMeshAgent>();
    }

    public void Start_State()
    {
        navMesh.isStopped = false;
        navMesh.SetDestination(Target_Point);
    }

    public void Excute()
    {
        if (navMesh.velocity == Vector3.zero)
        {
           Serch_Around();
        }
        Debug.Log("sound");
    }
    void Enemy_Patrol()
    {

    }
    public void End_State()
    {
        navMesh.isStopped = true;
    }
    private void Serch_Around()//주위를 탐색함
    {
        //타겟을 못 찾을 경우
        State_AI.GetComponent<EnemyAI>().Repeating_Patrol();
    }
}
