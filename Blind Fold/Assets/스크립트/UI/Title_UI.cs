using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title_UI : MonoBehaviour
{
    public GameObject SettingPanel;
    public GameObject Play_btn;
    public GameObject Tutorial_btn;
    public GameObject Setting_btn;
    public GameObject Exit_btn;

    public void PlayEnter()
    {
        //Play��ư ���� �� PlayScene���� �̵�
        SceneManager.LoadScene("PlayScene");
    }

    public void TutorialEnter()
    {
        //Tutorial��ư ���� �� TutorialScene���� �̵�
        SceneManager.LoadScene("TutorialScene");
    }

    public void SettingEnter()
    {
        //Setting��ư ���� �� SettingPanel����
        SettingPanel.SetActive(true);
    }

    public void ExitEnter()
    {
        Application.Quit();
    }
}
