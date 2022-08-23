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

    //loadgame을 위해 저장된 스테이지 stagenum을 받아와야함.

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
        //Newgame버튼 누를 시 stage 1으로 이동
        SceneManager.LoadScene(1);
    }

    public void LoadgameEnter()
    {
        //Loadgame버튼 누를 시 스테이지 리스트로 
        //GameObject.Find("StageManger").GetComponent<Save_Data>().LoadData();
        LoadUI.SetActive(true);
    }
    public void LoadStageEnter(int stage)
    {
        //Loadgame버튼 누를 시 해당 스테이지로 이동
        //GameObject.Find("StageManger").GetComponent<Save_Data>().LoadData();
        SceneManager.LoadScene(stage);
    }

    public void SettingEnter()
    {
        //Setting버튼 누를 시 SettingPanel나옴
        SettingPanel.SetActive(true);
    }

    public void ExitEnter()
    {
        Application.Quit();
    }
}
