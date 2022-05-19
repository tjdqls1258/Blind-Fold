using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play_UI : MonoBehaviour
{
    [SerializeField] static bool IsPause = false;
    [SerializeField] GameObject SettingPanel;
    [SerializeField] GameObject DialogueSystem;
    [SerializeField] GameObject Gameover_panel;
    [SerializeField] Button Gameover_m_btn;
    [SerializeField] Button Gameover_r_btn;
    [SerializeField] Text Gameover_text;
    [SerializeField] Image stamina;
    [SerializeField] Image charge;
    [SerializeField] Text Key_count;
    [SerializeField] Text Stone_count;
    [SerializeField] Image Aim;

    [SerializeField] GameObject Player;

    public bool isdie = false;

    void Awake()
    {
        Time.timeScale = 1.0f;
    }

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

        Key_count.text = "x" + Player.GetComponent<Player_Move>().collect_key;
        Stone_count.text = "x" + Player.GetComponent<Fire_Bullte>().get_count_bullet();
    }

    public void PauseEnter()
    {
        //Pause버튼 클릭
        if (Player)
        {
            Player.GetComponent<Fire_Bullte>().enabled = false;
        }
        Aim.GetComponent<Image>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SettingPanel.SetActive(true);
        Time.timeScale = 0.0f;
        IsPause = true;
    }

    public void Resume()
    {
        //Pause창에서 나옴
        if (Player)
        {
            Player.GetComponent<Fire_Bullte>().enabled = true;
            Player.GetComponent<Animator>().StopPlayback();
        }
        Aim.GetComponent<Image>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SettingPanel.SetActive(false);      
        IsPause = false;
        Time.timeScale = 1.0f;
    }

    public void MainMenu()
    {
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
        isdie = true;
        StartCoroutine(Fadein());
    }

    IEnumerator Fadein()
    {
        if (isdie == true)
        {
            yield return new WaitForSeconds(2.5f);
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
}
