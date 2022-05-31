using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Is_Die : MonoBehaviour
{
    [SerializeField] private GameObject Player_Head;
    [SerializeField] float Rot_Speed = 10.0f;
    public GameObject playui;

    public void Is_Die()
    {
        GetComponent<Player_Move>().enabled = false;
        GetComponent<Fire_Bullte>().enabled = false;
        GetComponent<Create_Echo>().enabled = false;
       
        Player_Head.GetComponent<Player_Rotate>().enabled = false;
        playui.GetComponent<Play_UI>().IsDie();
    }
}
