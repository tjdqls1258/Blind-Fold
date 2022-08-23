using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title_UI : MonoBehaviour
{
    [SerializeField] GameObject SettingPanel;
    private int loadstage_num;

    public Button Loadgame;
    public Text Load_text;

    public GameObject LoadUI, StageManager;

    public Button[] Stage;

    //loadgame�� ���� ����� �������� stagenum�� �޾ƿ;���.

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        loadstage_num = GameObject.Find("StageManger").GetComponent<Save_Data>().LoadStage_Num();
        if (loadstage_num > 1)
        {
            Loadgame.GetComponent<Button>().interactable = true;
            Load_text.color = new Color(255, 255, 255, 255);
        }
        else
        {
            Loadgame.GetComponent<Button>().interactable = false;
            Load_text.color = new Color(255, 255, 255, 0.3f);
        }
        for(int i = 0; i < StageManager.GetComponent<Save_Data>().LoadStage_Num() - 1; i++)
        {
            Stage[i].interactable = true;
        }
    }

    public void NewgameEnter()
    {
        //Newgame��ư ���� �� stage 1���� �̵�
        SceneManager.LoadScene(1);
    }

    public void LoadgameEnter()
    {
        //Loadgame��ư ���� �� �������� ����Ʈ�� 
        //GameObject.Find("StageManger").GetComponent<Save_Data>().LoadData();
        LoadUI.SetActive(true);
    }
    public void LoadStageEnter(int stage)
    {
        //Loadgame��ư ���� �� �ش� ���������� �̵�
        //GameObject.Find("StageManger").GetComponent<Save_Data>().LoadData();
        SceneManager.LoadScene(stage);
    }

    public void SettingEnter()
    {
        //Setting��ư ���� �� SettingPanel����
        SettingPanel.SetActive(true);
    }

    public void ExitEnter()
    {
        Application.Quit();
    }
}
