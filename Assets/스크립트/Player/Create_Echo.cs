using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Relay_Sound))]
public class Create_Echo : MonoBehaviour
{
    [SerializeField] private GameObject map_parent;
    [SerializeField] private float Echo_Power = 0.0f;
    [SerializeField] private float Min_Echo_Power = 3.0f;
    [SerializeField] private float Max_Echo_Power = 90.0f;

    [SerializeField] private Image Echo_Power_Charge;
    Relay_Sound relay_Sound;
    private void Start()
    {
        relay_Sound = GetComponent<Relay_Sound>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            if(Echo_Power >= Max_Echo_Power)
            {
                Echo_Power = Max_Echo_Power;
            }
            Echo_Power += Time.deltaTime * 3.0f;
            Echo_Power_Charge.fillAmount = Echo_Power/ Max_Echo_Power;
        }
        if(Input.GetKeyUp(KeyCode.Q))
        {
            map_parent.GetComponent<SimpleSonarShader_Parent>().StartSonarRing(transform.position, Echo_Power * Min_Echo_Power);
            Echo_Power = 0;
            Echo_Power_Charge.fillAmount = Echo_Power / Max_Echo_Power;
            relay_Sound.Serch_AI_And_Relay_Sound();
        }  
    }
}
