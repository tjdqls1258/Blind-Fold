using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Password_Locker : MonoBehaviour , I_Interplay_effect
{
    [SerializeField] private GameObject PasswordUI;
    [SerializeField] private GameObject UI;
    public bool Is_Open = false;

    private void Awake()
    {
        GetComponent<Interplay_machice>().SetInterplay(this);
    }

    public void Effect()
    {
        if(Is_Open)
        {
            return;
        }
        PasswordUI.SetActive(true);
        UI.GetComponent<Play_UI>().isdie = true;
        GameObject.Find("Player").GetComponent<Fire_Bullte>().enabled = false;
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
