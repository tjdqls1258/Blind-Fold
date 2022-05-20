using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class I_PatState : IState 
{
    [SerializeField] Transform[] m_WayPoints = null;
    NavMeshAgent navMesh = null;
    Animator Walk_Ain;
    GameObject AI;

    int m_count;
    float time = 0.0f;
    public float wait_time = 1.0f;

    public I_PatState(Transform[] transforms, NavMeshAgent nav, GameObject self, int count = 0)
    {
        time = 0;
        Walk_Ain = self.GetComponent<Animator>();
        AI = self;
        navMesh = nav;
        m_count = count;
        m_WayPoints = transforms;
    }

    public void Start_State()
    {
        Walk_Ain.SetBool("Is_Run", false);
        Walk_Ain.SetBool("Is_Walk", true);
        navMesh.ResetPath();
        navMesh.SetDestination(m_WayPoints[m_count].position);
        navMesh.destination = m_WayPoints[m_count].position;
        Debug.Log("is Working");
        navMesh.isStopped = false;
    }

    public void Excute()
    {
        if (navMesh.remainingDistance <= 0.5f)
        {
            Debug.Log(m_count);

            if (navMesh.velocity == Vector3.zero)
            {
                if (m_count <= m_WayPoints.Length)
                {
                    m_count++;
                }
                else
                {
                    m_count = 0;
                }

                Walk_Ain.SetBool("Is_Walk", false);
                navMesh.SetDestination(m_WayPoints[m_count].position);
                Debug.Log(m_WayPoints[m_count]);
                Walk_Ain.SetBool("Is_Walk", true);
            }
        }
    }

    public void End_State()
    {
        navMesh.ResetPath();
        Walk_Ain.SetBool("Is_Walk", false);
        navMesh.isStopped = true;
        AI.GetComponent<EnemyAI>().Pate_Count = m_count;
    }

    public AI_State Get_State()
    {
        return AI_State.Pat_State;
    }
}
