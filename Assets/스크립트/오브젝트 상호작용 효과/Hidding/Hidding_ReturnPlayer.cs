using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hidding_ReturnPlayer : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] private GameObject Cam;
    [SerializeField] private Text Say_GetOut;
    private Animator ain;

    private void OnEnable()
    {
        StartCoroutine(Enable_Do());
        StopCoroutine("Wait_For_End_Animation");
        ain = GetComponent<Animator>();
    }

    IEnumerator Enable_Do()
    {
        yield return null;
        Say_GetOut.text = "나가기";
    }

    private void Update()
    {
        Say_GetOut.text = "나가기";
        if (Input.GetKeyDown(KeyCode.E))
        {
            ain.SetTrigger("Out");
            StartCoroutine(Wait_For_End_Animation(ain.GetCurrentAnimatorStateInfo(0).length));
        }
    }

    IEnumerator Wait_For_End_Animation(float End_Time)
    {
        yield return new WaitForSeconds(End_Time);
        ain.ResetTrigger("Out");
        Cam.SetActive(false);
        Player.SetActive(true);
        this.enabled = false;
    }
}
