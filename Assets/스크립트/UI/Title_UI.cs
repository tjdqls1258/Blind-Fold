using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title_UI : MonoBehaviour
{
    public GameObject SettingPanel;

    public void PlayEnter()
    {
        //Play버튼 누를 시 PlayScene으로 이동
        SceneManager.LoadScene("PlayScene");
    }

    public void TutorialEnter()
    {
        //Tutorial버튼 누를 시 TutorialScene으로 이동
        SceneManager.LoadScene("TutorialScene");
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
