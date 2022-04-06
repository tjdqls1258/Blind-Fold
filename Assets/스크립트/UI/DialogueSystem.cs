using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text testtext;
    public bool scriptend;
    Queue<string> sentences = new Queue<string>();

    public void Begin(Dialogue info)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        scriptend = false;
        sentences.Clear();

        foreach (string sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
        }

        Next();
    }

    public void Next()
    {
        if (sentences.Count == 0)
        {
            End();
            return;
        }

        testtext.text = sentences.Dequeue();
    }

    public void End()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        scriptend = true;
        Debug.Log("end");
        //대화창 끄기
        Time.timeScale = 1.0f;
        Debug.Log("튜토 끝 - 재움직임");
    }
}
