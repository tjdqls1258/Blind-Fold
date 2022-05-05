using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title_UI : MonoBehaviour
{
    [SerializeField] GameObject SettingPanel;
    private int loadstage_num;

    //public Button Loadgame;
    //public Text Load_text;

    //loadgame�� ���� ����� �������� stagenum�� �޾ƿ;���.

    private void Start()
    {
        loadstage_num = GameObject.Find("StageManger").GetComponent<Save_Data>().LoadData() + 1;
        Debug.Log(GameObject.Find("StageManger").GetComponent<Save_Data>().LoadData());
    }

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
