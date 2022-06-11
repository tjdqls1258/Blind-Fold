using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheter : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private Light D_Light;
    
    private GameObject[] AI;
    // Start is called before the first frame update
    void Awake()
    {
        AI = GameObject.FindGameObjectsWithTag("AI");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            KeyUp();
            Staminer_Infinete();        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Kill_AI();
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            ∫˚¿Ã_¿÷¿∏∂Û();
        }
    }

    private void KeyUp()
    {
        Player.GetComponent<Player_Move>().collect_key = 99;
    }

    private void Kill_AI()
    {
        for(int count = 0; count < AI.Length; count++)
        {
            AI[count].SetActive(false);
        }
    }

    private void ∫˚¿Ã_¿÷¿∏∂Û()
    {
        D_Light.intensity = 1.0f;
    }

    private void Staminer_Infinete()
    {
        Player.GetComponent<Player_Move>().Stamina_Gage = 99999.0f;
    }
}
