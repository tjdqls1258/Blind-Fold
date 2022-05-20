using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class I_PatState : IState 
{
    [SerializeField] Transform[] m_WayPoints = null;
    NavMeshAgent navMesh = null;
    Animator Walk_Ain;

    int m_count = 0 , m_count_copy;
    float time = 0.0f;
    public float wait_time = 1.0f;

    public I_PatState(Transform[] transforms, NavMeshAgent nav, GameObject self)
    {
        time = 0;
        Walk_Ain = self.GetComponent<Animator>();
        navMesh = nav;
        m_WayPoints = transforms;
    }

    public void Start_State()
    {
        Walk_Ain.SetBool("Is_Run", false);
        Walk_Ain.SetBool("Is_Walk", true);
        m_count_copy = 0;
        navMesh.ResetPath();
        navMesh.SetDestination(m_WayPoints[m_count_copy].position);
        navMesh.destination = m_WayPoints[m_count_copy].position;
        Debug.Log("is Working");
        navMesh.isStopped = false;
    }

    public void Excute()
    {
        if (navMesh.remainingDistance <= 0.5f)
        {
            Debug.Log(m_count_copy);

            if (navMesh.velocity == Vector3.zero)
            {
                if (m_count_copy <= m_WayPoints.Length)
                {
                    m_count_copy++;
                }
                else
                {
                    m_count_copy = 0;
                }

                Walk_Ain.SetBool("Is_Walk", false);
                navMesh.SetDestination(m_WayPoints[m_count_copy].position);
                Debug.Log(m_WayPoints[m_count_copy]);
                Walk_Ain.SetBool("Is_Walk", true);
            }
        }
    }

    public void End_State()
    {
        navMesh.ResetPath();
        Walk_Ain.SetBool("Is_Walk", false);
        navMesh.isStopped = true;
    }

    public AI_State Get_State()
    {
        return AI_State.Pat_State;
    }
}
