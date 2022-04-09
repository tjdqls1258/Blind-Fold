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
         * ���¹̳� �� �ĵ� ��¡ �Լ� ��� �� ��
         * stamina.fillAmount = ���� ���¹̳�(�⺻ �ִ�, �����Ҹ��) / ��ü ���¹̳�(�ִ�ġ);
         * charge.fillAmount = ���� ��¡(�⺻ 0, ���� ������) / ��ü ��¡(�ִ�ġ);
         */
    }

    public void PauseEnter()
    {
        //Pause��ư Ŭ��
        Player.GetComponent<Fire_Bullte>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SettingPanel.SetActive(true);
        Time.timeScale = 0.0f;
        IsPause = true;
    }

    public void Resume()
    {
        //Pauseâ���� ����
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
        //MainMenu��ư�� ������ ���â�� ����
        WarningPanel.SetActive(true);
    }

    public void BacktoMainMenu()
    {
        //���â���� yes��ư ������ ���θ޴���
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
