using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Relay_Sound))]
public class Create_Echo : MonoBehaviour
{
    [SerializeField] private GameObject map_parent;
    [SerializeField] private float Echo_Power = 0.0f;
    //[SerializeField] private float Min_Echo_Power = 3.0f;
    //[SerializeField] private float Max_Echo_Power = 90.0f;

    //[SerializeField] private Image Echo_Power_Charge;
    Relay_Sound relay_Sound;
    private void Start()
    {
        relay_Sound = gameObject.GetComponent<Relay_Sound>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            relay_Sound.Serch_AI_And_Relay_Sound(1000.0f);
            map_parent.GetComponent<SimpleSonarShader_Parent>().StartSonarRing(transform.position, Echo_Power);
        }
    }
}
