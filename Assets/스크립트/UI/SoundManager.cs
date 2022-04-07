using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider MusicVolume;
    public Slider EffectVolume;
    public AudioSource MusicAudio;
    public AudioSource[] EffectAudio;

    private float M_vol_base = 1.0f;
    private float E_vol_base = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        M_vol_base = PlayerPrefs.GetFloat("M_vol_base", 1.0f);
        E_vol_base = PlayerPrefs.GetFloat("E_vol_base", 1.0f);

        MusicVolume.value = M_vol_base;
        EffectVolume.value = E_vol_base;

        MusicAudio.volume = MusicVolume.value;
        for (int i = 0; i < EffectAudio.Length; i++)
        {
            EffectAudio[i].volume = EffectVolume.value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SoundSetting();
    }

    public void SoundSetting()
    {
        MusicAudio.volume = MusicVolume.value;
        for (int i = 0; i < EffectAudio.Length; i++)
        {
            EffectAudio[i].volume = EffectVolume.value;
        }

        M_vol_base = MusicVolume.value;
        E_vol_base = EffectVolume.value;

        PlayerPrefs.SetFloat("M_vol_base", M_vol_base);
        PlayerPrefs.SetFloat("E_vol_base", E_vol_base);
    }
}
