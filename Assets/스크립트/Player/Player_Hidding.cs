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
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
    }

    public void Is_Hidding_End()
    {
        gameObject.GetComponent<Player_Move>().enabled = true;
        gameObject.GetComponent<Fire_Bullte>().enabled = true;
        gameObject.GetComponent<Create_Echo>().enabled = true;
        gameObject.GetComponent<CapsuleCollider>().enabled = true;
    }
}
