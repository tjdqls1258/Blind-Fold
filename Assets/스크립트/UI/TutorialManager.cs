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
        //step1����
        Time.timeScale = 0.0f;
        explanation.SetActive(true);
        Debug.Log("Ʃ�� ���� - ����");

        trigger.GetComponent<DialogueTrigger>().Trigger(0);//=>���� Ʈ���Ÿ� �������, �Լ��� �������� �ؾ��ҵ�
        Debug.Log("���� ����");

        yield return new WaitUntil(() => dialoguesystem.GetComponent<DialogueSystem>().scriptend == true);
        explanation.SetActive(false);

        //Ư������ �޼� questnum++;
        //step1 ����
        //1�� ����dialogue

        yield return new WaitUntil(() => questnum > 0);

        Debug.Log("�ι�° ����");
        //2�� dialogue
        explanation.SetActive(true);

        trigger.GetComponent<DialogueTrigger>().Trigger(1);

        yield return new WaitUntil(() => dialoguesystem.GetComponent<DialogueSystem>().scriptend == true);
        explanation.SetActive(false);

        yield return new WaitUntil(() => questnum > 1);
    }
}