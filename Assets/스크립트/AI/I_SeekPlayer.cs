using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class I_SeekPlayer : MonoBehaviour ,IState
{
    NavMeshAgent navMesh = null;
    Transform Target;
    Animator AI_Run_Ain;

    public I_SeekPlayer(NavMeshAgent nav, Transform target, GameObject self)
    {
        AI_Run_Ain = self.GetComponent<Animator>();
        navMesh = nav;
        Target = target;
    }

    public void Start_State()
    {
        navMesh.isStopped = false;
        AI_Run_Ain.SetBool("Is_Run", true);
    }

    public void Excute()
    {
        navMesh.SetDestination(Target.position);
    }

    public void End_State()
    {
        AI_Run_Ain.SetBool("Is_Run", false);
        Target = null;
        navMesh.isStopped = true;
    }

    public AI_State Get_State()
    {
        return AI_State.Seek_Player;
    }
}
