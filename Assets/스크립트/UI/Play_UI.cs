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
    public GameObject Gameover_panel;
    public Button Gameover_m_btn;
    public Button Gameover_r_btn;
    public Text Gameover_text;
    public Image stamina;
    public Image charge;

    public GameObject Player;

    public bool isdie = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !isdie)
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
        Player.GetComponent<Fire_Bullte>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SettingPanel.SetActive(true);
        Time.timeScale = 0.0f;
        IsPause = true;
    }

    public void Resume()
    {
        //Pause창에서 나옴
        Player.GetComponent<Fire_Bullte>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SettingPanel.SetActive(false);      
        IsPause = false;
        Time.timeScale = 1.0f;

        //if (DialogueSystem.GetComponent<DialogueSystem>().scriptend == false)
        //{
        //    Time.timeScale = 0.0f;
        //}
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

    public void IsDie()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        StartCoroutine(Fadein());
        isdie = true;
    }

    IEnumerator Fadein()
    {
        float fadecount = 0.0f;

        while (fadecount < 1.0f)
        {
            fadecount += 0.1f;
            Gameover_panel.GetComponent<Image>().color = new Color(0, 0, 0, fadecount);
            Gameover_m_btn.GetComponent<Image>().color = new Color(255, 255, 255, fadecount);
            Gameover_r_btn.GetComponent<Image>().color = new Color(255, 255, 255, fadecount);
            Gameover_text.color = new Color(255, 0, 0, fadecount);
            Gameover_panel.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
