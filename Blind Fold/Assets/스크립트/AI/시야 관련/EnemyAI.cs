using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent navMesh = null;

    [Header("Patrol Point")]
    [SerializeField] Transform[] m_WayPoints = null;
    int m_count = 0;

    [Header("View")]
    [SerializeField] private float View_Angle;
    [SerializeField] private float View_Distance;

    [Header("State")]
    [SerializeField] private State_Machine state_machine;

    void Awake()
    {
        navMesh = GetComponent<NavMeshAgent>();
        state_machine = GetComponent<State_Machine>();
        state_machine.Change_State(new I_PatState(m_WayPoints, navMesh));
    }

    private void Update()
    {
        state_machine.Run_State();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            Vector3 _direction = (other.transform.position - transform.position).normalized; //AI�� Ÿ���� �ٶ󺸴� ����
            float angle = Vector3.Angle(_direction, transform.forward);

            if (angle < View_Angle * 0.5f)
            {
                //���̿� ���� ���� ��ֹ��� �ִ��� ���� �Ǵ�.
                RaycastHit _hit;
                if (Physics.Raycast(transform.position, _direction, out _hit, View_Distance))
                {
                    if (_hit.transform.tag == "Player")
                    {
                        Debug.Log(_hit.transform.tag);
                        state_machine.Change_State(new I_SeekPlayer(navMesh, other.transform));
                    }
                }
            }
        }
    }
    public void Repeating_Patrol()
    {
        state_machine.Change_State(new I_PatState(m_WayPoints, navMesh));
    }
}