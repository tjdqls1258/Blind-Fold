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
        //Pause��ư Ŭ��
        SettingPanel.SetActive(true);
        Time.timeScale = 0.0f;
        IsPause = true;
    }

    public void Resume()
    {
        //Pauseâ���� ����
        SettingPanel.SetActive(false);
        Time.timeScale = 1.0f;
        IsPause = false;
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
