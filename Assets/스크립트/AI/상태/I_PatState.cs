using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class I_PatState : IState 
{
    [SerializeField] Transform[] m_WayPoints = null;
    NavMeshAgent navMesh = null;
    Animator Walk_Ain;

    int m_count = 0;
    float time = 0.0f;
    public float wait_time = 2.0f;

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
        int m_count_copy = Random.Range(0, m_WayPoints.Length);
        navMesh.ResetPath();
        navMesh.SetDestination(m_WayPoints[m_count_copy].position);
        navMesh.destination = m_WayPoints[m_count_copy].position;
        Debug.Log("is Working");
        navMesh.isStopped = false;
    }

    public void Excute()
    {
        time += Time.deltaTime;
        if (time > wait_time)
        {
            int m_count_copy = Random.Range(0, m_WayPoints.Length);
            if (navMesh.velocity == Vector3.zero)
            {
                Walk_Ain.SetBool("Is_Walk", false);
                if (m_count_copy != m_count)
                {
                    navMesh.SetDestination(m_WayPoints[m_count_copy].position);
                    m_count = m_count_copy;
                    Debug.Log(m_WayPoints[m_count_copy]);
                    Walk_Ain.SetBool("Is_Walk", true);
                }

            }
            
            time = 0;
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
