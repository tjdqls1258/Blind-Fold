using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Radio_Effect : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
    [SerializeField] private Text Text;
    [SerializeField] private string Talk;
    private bool Is_Ative = true;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && Is_Ative)
        {
            audio.Play();
            Text.text = Talk;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && Is_Ative)
        {
            Is_Ative = false;
            audio.Stop();
            Text.text = "";
        }
    }
}
