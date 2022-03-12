using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title_UI : MonoBehaviour
{
    public GameObject SettingPanel;
    public GameObject Play_btn;
    public GameObject Help_btn;
    public GameObject Setting_btn;
    public GameObject Exit_btn;

    public void PlayEnter()
    {
        //Play버튼 누를 시 PlayScene으로 이동
        SceneManager.LoadScene("PlayScene");
    }

    public void HelpEnter()
    {
        //도움말 or 튜토리얼 결정후 작성할 것
        //도움말이라면 패널 추가후 작업
        //튜토리얼이라면 튜토리얼 씬 추가후 작업
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
