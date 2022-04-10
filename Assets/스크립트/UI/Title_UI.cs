using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title_UI : MonoBehaviour
{
    public GameObject SettingPanel;
    public int loadstage_num;

    //public Button Loadgame;
    //public Text Load_text;

    //loadgame을 위해 저장된 스테이지 stagenum을 받아와야함.
    /*
     * void start()
     * {
     *  load 해야할 정보가 있으면 -> loadgame버튼을 반투명->불투명 + 버튼 활성화
     *  loadstage_num = load 정보(최근 stage)
     * }
     */

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
