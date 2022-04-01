using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class I_SeekPlayer : MonoBehaviour ,IState
{
    NavMeshAgent navMesh = null;

    Transform Target;
    public I_SeekPlayer(NavMeshAgent nav, Transform target)
    {
        navMesh = nav;
        Target = target;
    }

    public void Start_State()
    {
        navMesh.isStopped = false;
    }

    public void Excute()
    {
        navMesh.SetDestination(Target.position);
    }

    public void End_State()
    { 
        Target = null;
        navMesh.isStopped = true;
    }

    public AI_State Get_State()
    {
        return AI_State.Seek_Player;
    }
}
