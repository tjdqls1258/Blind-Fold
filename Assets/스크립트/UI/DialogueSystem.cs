using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] Text testtext;
    public bool scriptend;
    Queue<string> sentences = new Queue<string>();

    public GameObject Player;

    public void Begin(Dialogue info)
    {

        scriptend = false;
        sentences.Clear();

        foreach (string sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
        }

        //Next();
        StartCoroutine(Next_script());
    }

    public void Next()
    {
        if ((sentences.Count == 0) || scriptend)
        {
            End();
            return;
        }

        testtext.text = sentences.Dequeue();

        StartCoroutine(Next_script());
    }

    public void End()
    {
        Player.GetComponent<Fire_Bullte>().enabled = true;
        scriptend = true;
        Debug.Log("end");
        //��ȭâ ����
        Time.timeScale = 1.0f;
        Debug.Log("Ʃ�� �� - �������");
        testtext.text = "";
    }

    IEnumerator Next_script()
    {
        yield return new WaitForSeconds(3.0f);
        Next();
    }
}
