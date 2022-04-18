using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Relay_Sound : MonoBehaviour
{
    [Header("소리의 강약")]
    [Range(0, 1000.0f)] public float Sound_Power = 100.0f;

    [Header("소리의 감소 정도")]
    [SerializeField] 
    [Range(0.01f, 0.99f)] private float Decrease_Shame = 0.2f; //벽을 통과 했을 때 소리의 감소정도

    [Header("가청 거리")]
    [SerializeField] private float Audible_Distance = 100.0f; //최대 가청 거리
    [SerializeField] private float Min_Power = 5.0f; //최소 가청 세기

    private void OnCollisionEnter(Collision collision)
    {
        if (transform.tag != "Player")
        {
            Serch_AI_And_Relay_Sound(Sound_Power);
        }
    }

    public void Serch_AI_And_Relay_Sound(float Sound_Power)
    {
        Collider[] AI = Physics.OverlapSphere(gameObject.transform.position, Audible_Distance);
        
        for (int ai_count = 0; ai_count < AI.Length; ai_count++)
        {
            Relay_Target(Sound_Power, AI[ai_count].gameObject);
        }
    }

    private void Relay_Target(float Sound_Power, GameObject Target)
    {
        //가청거리보다 멀경우
        if (Vector3.SqrMagnitude(gameObject.transform.position - Target.transform.position) >= (Audible_Distance * Audible_Distance)) 
        {
            return;
        }

        RaycastHit[] Object_hit;
        float Audible_Sound = Sound_Power;
        //레이를 쏴서 벽이랑 충돌했을때 소리를 감소시킴
        Object_hit = Physics.RaycastAll(gameObject.transform.position, Target.transform.position, Sound_Power);
        
        for(int hit_count = 0; hit_count < Object_hit.Length; hit_count++)
        {
            if(Object_hit[hit_count].transform.tag == "Walls")
            {
                Audible_Sound *= Decrease_Shame; //소리의 계산
            }
        }
        //소리를 거리로 나눔.
        if (Audible_Sound - Vector3.Distance(gameObject.transform.position, Target.transform.position) > Min_Power)
        {
            //소리를 들었을 경우
            if (Target.GetComponent<State_Machine>())
            {
                if (Target.GetComponent<State_Machine>().aI_State == AI_State.Seek_Player)
                {
                    return;
                }

                NavMeshHit hit;
                if (NavMesh.SamplePosition(transform.position, out hit, 1.0f, NavMesh.AllAreas))
                {
                    Target.GetComponent<State_Machine>().Change_State(new I_SeekSound(gameObject.transform.position, Target));
                }
            }
        }
    }
}
