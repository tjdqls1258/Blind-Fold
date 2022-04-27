using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    //public Dialogue info;
    public Dialoguegroup groupinfo;

    private void Start()
    {
        int dindex = 0;
        int gindex = 0;
        List<Dictionary<string, object>> data_Script = CSVReader.Read("Script");//csv파일을 list에 저장

        //csv파일 내용을 넣은 list를 출력에 필요한 list에 그룹별로 재분배 및 저장
        while (data_Script != null)
        {
            groupinfo.d_group.Add(new Dialogue());

            for (int i = 0; i < data_Script.Count; i++)
            {
                if (data_Script[dindex]["Script"].ToString() == "end")
                {
                    gindex++;
                    dindex++;
                    break;
                }
                else
                {
                    groupinfo.d_group[gindex].sentences.Add(data_Script[dindex]["Script"].ToString());
                    dindex++;
                }
            }
        }
    }

    public void Trigger(int i)
    {
        DialogueSystem system = FindObjectOfType<DialogueSystem>();
        system.Begin(groupinfo.d_group[i]);
    }
}
