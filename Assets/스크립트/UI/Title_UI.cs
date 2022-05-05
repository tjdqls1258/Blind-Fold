using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title_UI : MonoBehaviour
{
    [SerializeField] GameObject SettingPanel;
    private int loadstage_num;

    //public Button Loadgame;
    //public Text Load_text;

    //loadgame을 위해 저장된 스테이지 stagenum을 받아와야함.

    private void Start()
    {
        loadstage_num = GameObject.Find("StageManger").GetComponent<Save_Data>().LoadData() + 1;
        Debug.Log(GameObject.Find("StageManger").GetComponent<Save_Data>().LoadData());
    }

    public void NewgameEnter()
    {
        //Newgame버튼 누를 시 stage 1으로 이동
        SceneManager.LoadScene(1);
    }

    public void LoadgameEnter()
    {
        //Loadgame버튼 누를 시 최근 플레이 stage로 이동
        SceneManager.LoadScene(loadstage_num);
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
