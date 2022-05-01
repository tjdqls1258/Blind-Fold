using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Password_Locker : MonoBehaviour , I_Interplay_effect
{
    [SerializeField] private GameObject Locker;
    [SerializeField] private GameObject UI;

    private void Awake()
    {
        GetComponent<Interplay_machice>().SetInterplay(this);
    }

    public void Effect()
    {
        Locker.SetActive(true);
        UI.GetComponent<Play_UI>().isdie = true;
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
