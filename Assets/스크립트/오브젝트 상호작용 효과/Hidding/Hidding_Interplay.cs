using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hidding_Interplay : MonoBehaviour, I_Interplay_effect
{
    [Header("*필수 내부 카메라 설정")]
    [SerializeField] private GameObject cam;
    private Animator ain;
    private bool Is_Seeking = false;

    private void Start()
    {
        GetComponent<Interplay_machice>().SetInterplay(this);
        ain = GetComponent<Animator>();
    }
    public void Effect()
    {
        if(Is_Seeking)
        {
            return;
        }
        GetComponent<Hidding_ReturnPlayer>().enabled = true;
        GetComponent<Hidding_ReturnPlayer>().Player = GameObject.Find("Player");
        GameObject.Find("Player").SetActive(false);
        cam.SetActive(true);
        ain.SetTrigger("In");
    }

    public void AI_Seek_Player_Now()
    {
        Debug.Log("추적 중");
        Is_Seeking = true;
    }

    public void AI_No_Seek_Player_Now()
    {
        Debug.Log("추적 종료");
        Is_Seeking = false;
    }
}
