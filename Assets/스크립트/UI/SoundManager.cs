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
    private bool Is_Awake = true;

    // Start is called before the first frame update
    void Start()
    {
        E_vol_base = PlayerPrefs.GetFloat("Effect_vol_base", 1.0f);
        M_vol_base = PlayerPrefs.GetFloat("M_vol_base", 1.0f);

        MusicVolume.value = M_vol_base;
        EffectVolume.value = E_vol_base;

        audio.SetFloat("musicVolume", (M_vol_base * 60.0f) - 40.0f);
        audio.SetFloat("sfxVolume", (E_vol_base * 60.0f) - 40.0f);
    }

    public void SoundSetting()
    {
        if(Is_Awake)
        {
            Is_Awake = false;
            return;
        }
        Debug.Log("Ω«ùÓ");
        M_vol_base = MusicVolume.value;
        E_vol_base = EffectVolume.value;

        PlayerPrefs.SetFloat("M_vol_base", M_vol_base);
        PlayerPrefs.SetFloat("Effect_vol_base", E_vol_base);

        if (M_vol_base <= 0.01f)
        {
            audio.SetFloat("musicVolume", -80.0f);
        }
        else
        {
            audio.SetFloat("musicVolume", (M_vol_base * 60.0f) - 40.0f);
        }

        if (E_vol_base <= 0.01f)
        {
            audio.SetFloat("sfxVolume", -80.0f);
        }
        else
        {
            audio.SetFloat("sfxVolume", (E_vol_base * 60.0f) - 40.0f);
        }
    }
}
