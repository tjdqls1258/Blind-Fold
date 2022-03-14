using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play_UI : MonoBehaviour
{
    public static bool IsPause = false;
    public GameObject SettingPanel;
    public GameObject WarningPanel;

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
        //MainMenu버튼을 누르면 경고창이 나옴
        WarningPanel.SetActive(true);
    }

    public void BacktoMainMenu()
    {
        //경고창에서 yes버튼 누르면 메인메뉴로
        SceneManager.LoadScene("Title");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
