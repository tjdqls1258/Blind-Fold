using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hidding_Interplay : MonoBehaviour, I_Interplay_effect
{
    [Header("*필수 내부 카메라 설정")]
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject AI;
    [SerializeField] private float Max_Distance_For_AI = 2.0f;
    private Animator ain;

    private void Start()
    {
        //AI = GameObject.Find("AI");
        GetComponent<Interplay_machice>().SetInterplay(this);
        ain = GetComponent<Animator>();
    }
    public void Effect()
    {
        if(Vector3.Distance(transform.position, AI.transform.position) <= Max_Distance_For_AI)
        {
            return;
        }
        GameObject.Find("AI").GetComponent<EnemyAI>().Repeating_Patrol(2.0f);
        GetComponent<Hidding_ReturnPlayer>().enabled = true;
        GetComponent<Hidding_ReturnPlayer>().Player = GameObject.Find("Player");
        GameObject Player =  GameObject.Find("Player");
        Player.GetComponent<Player_Hidding>().Is_Hidding_Start();
        Player.gameObject.transform.Find("Player_Head").gameObject.SetActive(false);
        cam.SetActive(true);
        ain.SetTrigger("In");
    }
}
