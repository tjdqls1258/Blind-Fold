using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Hidding : MonoBehaviour
{
    public void Is_Hidding_Start()
    {
        gameObject.GetComponent<Player_Move>().enabled = false;
        gameObject.GetComponent<Fire_Bullte>().enabled = false; 
        gameObject.GetComponent<Create_Echo>().enabled = false;   
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponentInChildren<Interplay_Object>().enabled = false;
        gameObject.GetComponentInChildren<Player_Rotate>().enabled = false;
    }

    public void Is_Hidding_End()
    {
        gameObject.GetComponent<Player_Move>().enabled = true;
        gameObject.GetComponent<Fire_Bullte>().enabled = true;
        gameObject.GetComponent<Create_Echo>().enabled = true;
        gameObject.GetComponent<BoxCollider>().enabled = true;
        gameObject.GetComponentInChildren<Interplay_Object>().enabled = true;
        gameObject.GetComponentInChildren<Player_Rotate>().enabled = true;
    }
}
