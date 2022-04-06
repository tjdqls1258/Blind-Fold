using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play_UI : MonoBehaviour
{
    public static bool IsPause = false;
    public GameObject SettingPanel;
    public GameObject WarningPanel;
    public GameObject DialogueSystem;
    public Image stamina;
    public Image charge;

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

        /*
         * 스태미너 및 파동 차징 함수 들어 갈 곳
         * stamina.fillAmount = 현재 스태미나(기본 최대, 점점소모됨) / 전체 스태미나(최대치);
         * charge.fillAmount = 현재 차징(기본 0, 점점 차오름) / 전체 차징(최대치);
         */
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
        IsPause = false;

        if (DialogueSystem.GetComponent<DialogueSystem>().scriptend == true)
        {
            Time.timeScale = 1.0f;
        }
        else
        {
            Time.timeScale = 0.0f;
        }
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
