using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent navMesh = null;

    [Header("Patrol Point")]
    [SerializeField] Transform[] m_WayPoints = null;
    Transform Start_Transform;
    int m_count = 0;

    [Header("View")]
    [SerializeField] private GameObject AI_Head;
    [SerializeField] private float View_Angle;
    [SerializeField] private float View_Distance;

    [Header("State")]
    [SerializeField] private State_Machine state_machine;

    private Animator ain;

    private AudioSource audio;
    public bool Find_Player = false;

    void Awake()
    {
        navMesh = GetComponent<NavMeshAgent>();
        state_machine = GetComponent<State_Machine>();
        if (m_WayPoints.Length == 0)
        {
            Start_Transform = gameObject.transform;
            state_machine.Change_State(new I_IdleState(Start_Transform.position, Start_Transform.rotation.eulerAngles));
        }
        else
        {
            state_machine.Change_State(new I_PatState(m_WayPoints, navMesh, gameObject));
        }
        ain = GetComponent<Animator>();
        ain.SetBool("Is_Idle", true);
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        state_machine.Run_State();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            Vector3 _direction = (other.transform.position - AI_Head.transform.position).normalized; //AI가 타겟을 바라보는 방향
            float angle = Vector3.Angle(_direction, AI_Head.transform.forward);
            RaycastHit _hit;
            if (angle < (View_Angle) * 0.5f && Physics.Raycast(AI_Head.transform.position, _direction, out _hit, View_Distance))
            {
                //사이에 벽과 같은 장애물이 있는지 여부 판단.
                if (_hit.transform.tag == "Player")
                {
                    StartCoroutine(Seek_Player(other.gameObject));
                }
            }
        }
    }

    public IEnumerator Seek_Player(GameObject Target)
    {
        //**** 대충 울부짖는 소리와 애니메이션 ****
        if (!Find_Player)
        {
            Find_Player = true;
            ain.SetBool("Is_Finder", true);
            navMesh.isStopped = true;
            audio.PlayOneShot(audio.clip);
            yield return new WaitForSeconds(2.0f);

            state_machine.Change_State(new I_SeekPlayer(navMesh, Target, this.gameObject));
            navMesh.isStopped = false;
            ain.SetBool("Is_Finder", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(Stop_Seek(5.0f));
    }

    public void Repeating_Patrol(float Wait_Time)
    {
        StartCoroutine(Stop_Seek(Wait_Time));
    }

    public IEnumerator Stop_Seek(float Wait_Time)
    {
        yield return new WaitForSeconds(Wait_Time);
        Find_Player = false;
        if (m_WayPoints.Length == 0)
        {
            navMesh.SetDestination(Start_Transform.position);
            state_machine.Change_State(new I_IdleState(Start_Transform.position,Start_Transform.rotation.eulerAngles));
        }
        else
        {
            state_machine.Change_State(new I_PatState(m_WayPoints, navMesh, gameObject));
        }
    }
}