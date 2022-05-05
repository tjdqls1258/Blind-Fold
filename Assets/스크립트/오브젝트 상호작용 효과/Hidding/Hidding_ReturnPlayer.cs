using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hidding_ReturnPlayer : MonoBehaviour
{
    [Header("*필수 해당 오브젝트 내부 카메라, 플레이어, UI텍스트 설정")]
    public GameObject Player;
    [SerializeField] private GameObject Cam;
    [SerializeField] private GameObject light;
    [SerializeField] private Text Say_GetOut;
    private Animator ani;

    bool Player_Hidding = false;
    private void Start()
    {
        Say_GetOut = GameObject.Find("Interplay_text").GetComponent<Text>();
    }

    private void OnEnable()
    {
        StartCoroutine(Enable_Do());
        StopCoroutine("Wait_For_End_Animation");
        ani = GetComponent<Animator>();
        Player_Hidding = true;
    }

    IEnumerator Enable_Do()
    {
        yield return null;
        Say_GetOut.text = "나가기";
        yield return new WaitForSeconds(1.0f);
        light.SetActive(true);
    }

    private void Update()
    {
        Say_GetOut.text = "나가기";
        if ((Input.GetKeyDown(KeyCode.E)) && (ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) && Player_Hidding)
        {
            ani.SetTrigger("Out");
            StartCoroutine(Wait_For_End_Animation(ani.GetCurrentAnimatorStateInfo(0).length + 0.4f));
        }
    }

    IEnumerator Wait_For_End_Animation(float End_Time)
    {
        Player_Hidding = false;
        light.SetActive(false);
        yield return new WaitForSeconds(End_Time);
        ani.ResetTrigger("Out");
        Cam.SetActive(false);
        Player.SetActive(true);
        this.enabled = false;
    }
}
