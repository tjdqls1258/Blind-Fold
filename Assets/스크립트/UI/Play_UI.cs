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
         * ���¹̳� �� �ĵ� ��¡ �Լ� ��� �� ��
         * stamina.fillAmount = ���� ���¹̳�(�⺻ �ִ�, �����Ҹ��) / ��ü ���¹̳�(�ִ�ġ);
         * charge.fillAmount = ���� ��¡(�⺻ 0, ���� ������) / ��ü ��¡(�ִ�ġ);
         */
    }

    public void PauseEnter()
    {
        //Pause��ư Ŭ��
        SettingPanel.SetActive(true);
        Time.timeScale = 0.0f;
        IsPause = true;
    }

    public void Resume()
    {
        //Pauseâ���� ����
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
}
