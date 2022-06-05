using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Radio_Effect : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
    [SerializeField] private Text Text;
    [SerializeField] private string Talk;
    private Light light;
    private bool Is_Ative = true;

    [SerializeField] GameObject UI;
    public int radio_num;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        light = GetComponent<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && Is_Ative)
        {
            Is_Ative = false;
            if (audio)
            {
                audio.Play();
            }
            if (light)
            {
                light.enabled = true;
            }
            //Text.text = Talk;

            UI.GetComponent<TutorialManager>().radio_script(radio_num);
        }
    }
}
