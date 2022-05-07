using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class I_SeekPlayer : MonoBehaviour ,IState
{
    NavMeshAgent navMesh = null;
    GameObject Target;
    GameObject State_AI;
    Animator AI_Run_Ain;
    GameObject[] Map_Hidding;

    public I_SeekPlayer(NavMeshAgent nav, GameObject target, GameObject self)
    {
        Map_Hidding = GameObject.FindGameObjectsWithTag("Hidding");
        State_AI = self;
        AI_Run_Ain = self.GetComponent<Animator>();
        navMesh = nav;
        Target = target;
    }

    public void Start_State()
    {
        foreach (GameObject count in Map_Hidding)
        {
            count.GetComponent<Hidding_Interplay>().AI_Seek_Player_Now();
        }
       
        navMesh.isStopped = false;
        AI_Run_Ain.SetBool("Is_Run", true);
    }

    public void Excute()
    {
        navMesh.SetDestination(Target.transform.position);
        NavMeshHit hit;
        if (!NavMesh.SamplePosition(State_AI.transform.position, out hit, 1.0f, NavMesh.AllAreas))
        {
            State_AI.GetComponent<EnemyAI>().Repeating_Patrol(0.01f);
        }
    }

    public void End_State()
    {
        foreach (GameObject count in Map_Hidding)
        {
            count.GetComponent<Hidding_Interplay>().AI_No_Seek_Player_Now();
        }

        AI_Run_Ain.SetBool("Is_Run", false);
        Target = null;
        navMesh.ResetPath();
        navMesh.isStopped = true;
    }

    public AI_State Get_State()
    {
        return AI_State.Seek_Player;
    }
}
