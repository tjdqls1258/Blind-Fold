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
    [SerializeField] private GameObject AI_Head;
    [SerializeField] private float View_Angle;
    [SerializeField] private float View_Distance;

    [Header("State")]
    [SerializeField] private State_Machine state_machine;

    private Animator ain;

    private AudioSource audio;
    private bool Find_Player = false;

    void Awake()
    {
        navMesh = GetComponent<NavMeshAgent>();
        state_machine = GetComponent<State_Machine>();
        state_machine.Change_State(new I_PatState(m_WayPoints, navMesh, gameObject));
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
            Vector3 _direction = (other.transform.position - AI_Head.transform.position).normalized; //AI�� Ÿ���� �ٶ󺸴� ����
            float angle = Vector3.Angle(_direction, AI_Head.transform.forward);

            ////����� ���� ���.
            Vector3 _leftBoundary =
                new Vector3(
                    Mathf.Sin((((-View_Angle) * 0.5f) + AI_Head.transform.eulerAngles.y + 90) * Mathf.Deg2Rad),
                    0.0f,
                Mathf.Cos((((-View_Angle) * 0.5f) + AI_Head.transform.eulerAngles.y + 90) * Mathf.Deg2Rad));

            Vector3 _rightBoundary =
                new Vector3(
                    Mathf.Sin((((View_Angle) * 0.5f) + AI_Head.transform.eulerAngles.y+ 90) * Mathf.Deg2Rad),
                    0.0f,
                Mathf.Cos((((View_Angle ) * 0.5f) + AI_Head.transform.eulerAngles.y + 90) * Mathf.Deg2Rad));

            Debug.DrawRay(AI_Head.transform.position + AI_Head.transform.up, _leftBoundary * View_Distance, Color.red);
            Debug.DrawRay(AI_Head.transform.position + AI_Head.transform.up, _rightBoundary * View_Distance, Color.red);
            //����� ���� ��

            if (angle < (View_Angle) * 0.5f )
            {
                StopCoroutine(Stop_Seek(10.0f));
                //���̿� ���� ���� ��ֹ��� �ִ��� ���� �Ǵ�.
                RaycastHit _hit;
                if (Physics.Raycast(AI_Head.transform.position, _direction, out _hit, View_Distance))
                {
                    if (_hit.transform.tag == "Player")
                    {
                        Debug.Log(_hit.transform.tag);
                        StartCoroutine(Seek_Player(other.gameObject));
                    }
                }
            }
        }
    }

    public IEnumerator Seek_Player(GameObject Target)
    {
        //**** ���� ���¢�� �Ҹ��� �ִϸ��̼� ****
        if (!Find_Player)
        {
            audio.PlayOneShot(audio.clip);
            ain.SetBool("Is_Finder", true);
            navMesh.isStopped = true;
            Find_Player = true;
            yield return new WaitForSeconds(2.0f);
            ain.SetBool("Is_Finder", false);
            state_machine.Change_State(new I_SeekPlayer(navMesh, Target.transform, this.gameObject));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine("Stop_Seek");
    }

    public void Repeating_Patrol(float Wait_Time)
    {
        StopCoroutine(Stop_Seek(Wait_Time));
    }

    public IEnumerator Stop_Seek(float Wait_Time)
    {
        yield return new WaitForSeconds(10.0f);
        Find_Player = false;
        state_machine.Change_State(new I_PatState(m_WayPoints, navMesh, gameObject));
    }
}