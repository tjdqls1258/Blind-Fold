using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class I_PatState : IState 
{
    [SerializeField] Transform[] m_WayPoints = null;
    NavMeshAgent navMesh = null;

    int m_count = 0;
    float time = 0.0f;
    public float wait_time = 2.0f;

    public I_PatState(Transform[] transforms, NavMeshAgent nav)
    {
        navMesh = nav;
        m_WayPoints = transforms;
    }

    public void Start_State()
    {
        navMesh.isStopped = false;
        //InvokeRepeating("Enemy_Patrol",0.0f,2.0f);
    }

    public void Excute()
    {
        time += Time.deltaTime;
        if (time > wait_time)
        {
            int m_count_copy = Random.Range(0, m_WayPoints.Length);
            if (navMesh.velocity == Vector3.zero)
            {
                if (m_count_copy != m_count)
                {
                    navMesh.SetDestination(m_WayPoints[m_count].position);
                    Serch_Around();
                    m_count = m_count_copy;
                }
            }
            time = 0;
        }
    }

    void Enemy_Patrol()
    {
        
    }

    public void End_State()
    {
        //CancelInvoke("Enemy_Patrol");
        navMesh.isStopped = true;
    }

    private void Serch_Around()//주위를 둘러봄
    {

    }

    public AI_State Get_State()
    {
        return AI_State.Pat_State;
    }
}
