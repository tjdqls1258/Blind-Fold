using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relay_Sound : MonoBehaviour
{
    [SerializeField]
    [Range(0, 1000.0f)] float Sound_Power = 100.0f;

    [SerializeField] 
    [Range(0.01f, 0.99f)] float Decrease_Shame = 0.2f; //���� ��� ���� �� �Ҹ��� ��������

    [SerializeField] float Audible_Distance = 10.0f; //�ִ� ��û �Ÿ�
    [SerializeField] float Min_Power = 5.0f; //�ּ� ��û ����

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] AI = Physics.OverlapSphere(gameObject.transform.position, Audible_Distance);
        for(int ai_count = 0;  ai_count< AI.Length; ai_count++)
        {
            Relay_Target(100.0f, AI[ai_count].gameObject);
        }
    }
    private void Relay_Target(float Sound_Power, GameObject Target)
    {
        //Debug.Log(Target.GetComponent<State_Machine>().ToString());
        //if (Target.GetComponent<State_Machine>().aI_State == AI_State.Seek_Player)
        //{
        //    return;
        //}
        //��û�Ÿ����� �ְ��
        if (Vector3.SqrMagnitude(transform.position - Target.transform.position) >= (Audible_Distance * Audible_Distance)) 
        {
            return;
        }

        RaycastHit[] Object_hit;
        float Audible_Sound = Sound_Power;
        //���̸� ���� ���̶� �浹������ �Ҹ��� ���ҽ�Ŵ
        Object_hit = Physics.RaycastAll(transform.position, Target.transform.position, Sound_Power);
        
        for(int hit_count = 0; hit_count < Object_hit.Length; hit_count++)
        {
            if(Object_hit[hit_count].transform.tag == "Walls")
            {
                Audible_Sound *= Decrease_Shame; //�Ҹ��� ���
            }
        }
        //�Ҹ��� �Ÿ��� ����.
        if (Audible_Sound - Vector3.Distance(transform.position, Target.transform.position) > Min_Power)
        {
            //�Ҹ��� ����� ���
            if (Target.GetComponent<State_Machine>())
            {
                if (Target.GetComponent<State_Machine>().aI_State == AI_State.Seek_Player)
                {
                    return;
                }
                Target.GetComponent<State_Machine>().Change_State(new I_SeekSound(transform.position, Target));
            }
        }
    }
}
