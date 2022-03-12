using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_UI : MonoBehaviour
{
    public static bool IsPause = false;
    public GameObject SettingPanel;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        { 
            if(IsPause)
            {
                Resume();
            }
            else
            {
                PauseEnter();
            }
        }
    }

    public void PauseEnter()
    {
        //Pause버튼 클릭
        SettingPanel.SetActive(true);
        Time.timeScale = 0.0f;
        IsPause = true;
    }

    public void Resume()
    {
        //Pause창에서 나옴
        SettingPanel.SetActive(false);
        Time.timeScale = 1.0f;
        IsPause = false;
    }

    public void MainMenu()
    {
        //MainMenu버튼 누를 시 바로 갈지, 경고창을 한번 더 띄울지 결정후 작성
    }
}
