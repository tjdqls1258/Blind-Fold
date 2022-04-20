using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hidding_ReturnPlayer : MonoBehaviour
{
    [Header("*�ʼ� �ش� ������Ʈ ���� ī�޶�, �÷��̾�, UI�ؽ�Ʈ ����")]
    public GameObject Player;
    [SerializeField] private GameObject Cam;
    [SerializeField] private Text Say_GetOut;
    private Animator ani;

    bool Player_Hidding = false;
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
        Say_GetOut.text = "������";
    }

    private void Update()
    {
        Say_GetOut.text = "������";
        if ((Input.GetKeyDown(KeyCode.E)) && (ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) && Player_Hidding)
        {
            ani.SetTrigger("Out");
            StartCoroutine(Wait_For_End_Animation(ani.GetCurrentAnimatorStateInfo(0).length + 0.4f));
        }
    }

    IEnumerator Wait_For_End_Animation(float End_Time)
    {
        Player_Hidding = false;
        yield return new WaitForSeconds(End_Time);
        ani.ResetTrigger("Out");
        Cam.SetActive(false);
        Player.SetActive(true);
        this.enabled = false;
    }
}
