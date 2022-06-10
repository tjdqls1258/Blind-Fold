using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Sound_Setting : MonoBehaviour
{
    private AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        audio.volume = PlayerPrefs.GetFloat("E_vol_base");
    }
}
