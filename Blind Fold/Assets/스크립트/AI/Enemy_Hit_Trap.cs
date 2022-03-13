using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Hit_Trap : MonoBehaviour
{
    [SerializeField] GameObject Enemy;

    private void Awake()
    {
        Enemy = transform.parent.gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Trap")
        {
            Enemy.GetComponent<SphereCollider>().enabled = false;
            Enemy.GetComponent<EnemyAI>().enabled = false; //AI정지
            Enemy.GetComponent<NavMeshAgent>().SetDestination(transform.position);
            Enemy.GetComponent<NavMeshAgent>().isStopped = true;

            Destroy(other.gameObject);
            Invoke("Patrol_Again", 2.0f); //2초후에 상태 변경
        }
    }

    private void Patrol_Again()
    {
        Enemy.GetComponent<SphereCollider>().enabled = true;
        Enemy.GetComponent<NavMeshAgent>().isStopped = false;
        Enemy.GetComponent<EnemyAI>().enabled = true;
        Enemy.GetComponent<EnemyAI>().Repeating_Patrol();
    }
}
