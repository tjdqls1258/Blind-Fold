using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public int questnum;
    public GameObject trigger;
    public GameObject dialoguesystem;
    public GameObject explanation;
    // Start is called before the first frame update
    void Start()
    {
        questnum = 0;
        StartCoroutine(starttuto());
    }

    IEnumerator starttuto()
    {
        yield return new WaitForSeconds(1.0f);
        //step1시작
        Time.timeScale = 0.0f;
        explanation.SetActive(true);
        Debug.Log("튜토 시작 - 정지");

        trigger.GetComponent<DialogueTrigger>().Trigger(0);//=>따로 트리거를 만들던가, 함수만 따오던가 해야할듯
        Debug.Log("설명 시작");

        yield return new WaitUntil(() => dialoguesystem.GetComponent<DialogueSystem>().scriptend == true);
        explanation.SetActive(false);

        //특정조건 달성 questnum++;
        //step1 종료
        //1번 설명dialogue

        yield return new WaitUntil(() => questnum > 0);

        Debug.Log("두번째 스텝");
        //2번 dialogue
        explanation.SetActive(true);

        trigger.GetComponent<DialogueTrigger>().Trigger(1);

        yield return new WaitUntil(() => dialoguesystem.GetComponent<DialogueSystem>().scriptend == true);
        explanation.SetActive(false);

        yield return new WaitUntil(() => questnum > 1);
    }
}