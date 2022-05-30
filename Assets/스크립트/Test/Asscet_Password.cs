using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asscet_Password : MonoBehaviour
{
    [SerializeField] Password_Data Hintnum1, Hintnum2, Hintnum3;
    [SerializeField] private Text Input1, Input2, Input3;
    [SerializeField] private GameObject Locker;

    public void Is_Asscet()
    {
        if(Hintnum1.Pass_Num == int.Parse(Input1.text) && 
            Hintnum2.Pass_Num == int.Parse(Input2.text) &&
            Hintnum3.Pass_Num == int.Parse(Input3.text))
        {
            Locker.GetComponent<Password_Locker>().Is_Open = true;
            Locker.GetComponent<Collider>().enabled = false;
            Locker.GetComponentInChildren<Animator>().SetBool("Is_Open", true);
            Debug.Log("성공");
        }
        else
        {
            Debug.Log("실패");
        }
        Cursor.lockState = CursorLockMode.Locked;
        GetComponentInParent<Play_UI>().isdie = false;
        GameObject.Find("Player").GetComponent<Fire_Bullte>().enabled = true;
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }

    public void Set_Ative_False()
    {
        Cursor.lockState = CursorLockMode.Locked;
        GetComponentInParent<Play_UI>().isdie = false;
        GameObject.Find("Player").GetComponent<Animator>().StopPlayback();
        GameObject.Find("Player").GetComponent<Fire_Bullte>().enabled = true;
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }

    public void Up_Button(Text Input)
    {
        if (int.Parse(Input.text) < 10)
        {
            int StringInt = int.Parse(Input.text) + 1;
            Input.text = StringInt.ToString();
        }
        if (int.Parse(Input.text) == 10)
        {
            int StringInt = 0;
            Input.text = StringInt.ToString();
        }
    }

    public void Down_Button(Text Input)
    {
        if (int.Parse(Input.text) >= 0)
        {
            int StringInt = int.Parse(Input.text) - 1;
            Input.text = StringInt.ToString();
        }
        if(int.Parse(Input.text) == -1)
        {
            int StringInt = 9;
            Input.text = StringInt.ToString();
        }
    }

}
