using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider MusicVolume;
    [SerializeField] Slider EffectVolume;
    [SerializeField] AudioMixer audioMixer;

    private float M_vol_base = 1.0f;
    private float E_vol_base = 1.0f;

    private float tempmusicvol;
    private float tempeffectvol;

    private bool m_toggle = true;
    private bool e_toggle = true;

    // Start is called before the first frame update
    void Start()
    {
        M_vol_base = PlayerPrefs.GetFloat("M_vol_base");
        E_vol_base = PlayerPrefs.GetFloat("E_vol_base");

        MusicVolume.value = M_vol_base;
        EffectVolume.value = E_vol_base;

        audioMixer.SetFloat("musicVolume", (M_vol_base * 100) - 80.0f);
        audioMixer.SetFloat("sfxVolume", (E_vol_base * 100) - 80.0f);
    }

    public void SoundSetting()
    {
        M_vol_base = MusicVolume.value;
        E_vol_base = EffectVolume.value;

        audioMixer.SetFloat("musicVolume", (M_vol_base * 100) - 80.0f);
        audioMixer.SetFloat("sfxVolume", (E_vol_base * 100) - 80.0f);

        PlayerPrefs.SetFloat("M_vol_base", M_vol_base);
        PlayerPrefs.SetFloat("E_vol_base", E_vol_base);
    }

    public void musictoggle()
    {
        if (m_toggle)
        {
            tempmusicvol = MusicVolume.value;
            audioMixer.SetFloat("musicVolume", 0.0f);
            MusicVolume.value = 0.0f;
            m_toggle = false;
        }
        else
        {
            audioMixer.SetFloat("musicVolume", tempmusicvol);
            MusicVolume.value = tempmusicvol;
            m_toggle = true;
        } 
    }

    public void effecttoggle()
    {
        if (e_toggle)
        {
            tempeffectvol = EffectVolume.value;
            audioMixer.SetFloat("sfxVolume", 0.0f);
            EffectVolume.value = 0.0f;
            e_toggle = false;
        }
        else
        {
            audioMixer.SetFloat("sfxVolume", tempmusicvol);
            EffectVolume.value = tempeffectvol;
            e_toggle = true;
        }
    }
}
