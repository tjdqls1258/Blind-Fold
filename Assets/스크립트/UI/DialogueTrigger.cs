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
        List<Dictionary<string, object>> data_Script = CSVReader.Read("Script");//csv������ list�� ����

        //csv���� ������ ���� list�� ��¿� �ʿ��� list�� �׷캰�� ��й� �� ����
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
