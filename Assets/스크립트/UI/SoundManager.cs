using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider MusicVolume;
    [SerializeField] Slider EffectVolume;
    [SerializeField] AudioMixer audio;

    private float M_vol_base = 1.0f;
    private float E_vol_base = 1.0f;

    private float tempmusicvol;
    private float tempeffectvol;

    private bool m_toggle = true;
    private bool e_toggle = true;

    // Start is called before the first frame update
    void Start()
    {
        M_vol_base = PlayerPrefs.GetFloat("M_vol_base", 1.0f);
        E_vol_base = PlayerPrefs.GetFloat("E_vol_base", 1.0f);

        MusicVolume.value = M_vol_base;
        EffectVolume.value = E_vol_base;

        audio.SetFloat("musicVolume", (M_vol_base * 100.0f) - 80.0f);
        audio.SetFloat("sfxVolume", (E_vol_base * 100.0f) - 80.0f);
    }

    public void SoundSetting()
    {
        M_vol_base = MusicVolume.value;
        E_vol_base = EffectVolume.value;

        if (M_vol_base <= 0.01f)
        {
            audio.SetFloat("musicVolume", (M_vol_base * 60.0f) - 80.0f);
        }
        else
        {
            audio.SetFloat("musicVolume", (M_vol_base * 60.0f) - 40.0f);
        }

        if (E_vol_base <= 0.01f)
        {
            audio.SetFloat("sfxVolume", (E_vol_base * 60.0f) - 80.0f);
        }
        else
        {
            audio.SetFloat("sfxVolume", (E_vol_base * 60.0f) - 40.0f);
        }

        PlayerPrefs.SetFloat("M_vol_base", M_vol_base);
        PlayerPrefs.SetFloat("E_vol_base", E_vol_base);
    }

    public void musictoggle()
    {
        if (m_toggle)
        {
            tempmusicvol = MusicVolume.value;
            audio.SetFloat("musicVolume", -80.0f);
            MusicVolume.value = 0;
            m_toggle = false;
        }
        else
        {
            MusicVolume.value = tempmusicvol;
            audio.SetFloat("musicVolume", (tempmusicvol * 100.0f) - 40.0f);
            m_toggle = true;
        }
    }

    public void effecttoggle()
    {
        if (e_toggle)
        {
            tempeffectvol = EffectVolume.value;
            audio.SetFloat("sfxVolume", -80.0f);
            EffectVolume.value = 0;
            e_toggle = false;
        }
        else
        {
            EffectVolume.value = tempeffectvol;
            audio.SetFloat("sfxVolume", (tempeffectvol * 100.0f) - 40.0f);
            e_toggle = true;
        }
    }
}
