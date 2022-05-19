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

        Next();
        //StartCoroutine(Next_script());
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
        //대화창 끄기
        Time.timeScale = 1.0f;
        Debug.Log("튜토 끝 - 재움직임");
        testtext.text = "";
    }

    IEnumerator Next_script()
    {
        //float fadecount = 1.0f;
        yield return new WaitForSeconds(2.0f);

        //while (fadecount > 0.0f)
        //{
        //    fadecount -= 0.03f;
        //    if (fadecount < 0.0f)
        //    {
        //        fadecount = 0.0f;
        //    }
        //    testtext.color = new Color(255, 255, 255, fadecount);
        //    yield return new WaitForSeconds(0.1f);
            
        //}

        Next();
    }
}
