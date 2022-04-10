using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title_UI : MonoBehaviour
{
    public GameObject SettingPanel;
    public int loadstage_num;

    //public Button Loadgame;
    //public Text Load_text;

    //loadgame�� ���� ����� �������� stagenum�� �޾ƿ;���.
    /*
     * void start()
     * {
     *  load �ؾ��� ������ ������ -> loadgame��ư�� ������->������ + ��ư Ȱ��ȭ
     *  loadstage_num = load ����(�ֱ� stage)
     * }
     */

    public void NewgameEnter()
    {
        //Newgame��ư ���� �� stage 1���� �̵�
        SceneManager.LoadScene(1);
    }

    public void LoadgameEnter()
    {
        //Loadgame��ư ���� �� �ֱ� �÷��� stage�� �̵�
        SceneManager.LoadScene(loadstage_num);
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
