using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Active : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Player_Head;

    private void OnEnable()
    {
        Player.GetComponent<Player_Move>().enabled = true;
        Player.GetComponent<Create_Echo>().enabled = true;
        Player.GetComponent<Fire_Bullte>().enabled = true;
        Player_Head.GetComponent<Player_Rotate>().enabled = true;
        Player_Head.GetComponent<Camera>().enabled = true;
        Player_Head.GetComponent<Interplay_Object>().enabled = true;
    }
}
