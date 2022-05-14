using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Title_Changer : MonoBehaviour
{
    [SerializeField] private Light D_Light;
    [SerializeField] private GameObject Object_1, Object_2;
    [SerializeField] private float Timer;
    [SerializeField] private float Switch_Time;
    [SerializeField] private int Min_Random, Max_Random;
    [SerializeField] private PostProcessVolume postProcessVolume;
    int Resicle_Count;

    private float Sec = 0;
    private void Awake()
    {
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        Sec += Time.deltaTime;
        if(Sec >= Timer)
        {
            Sec = 0;
            Resicle_Count = Random.Range(Min_Random, Max_Random);
            StartCoroutine(Thoter(Resicle_Count));
        }
    }

    IEnumerator Thoter(int resicle)
    {
        for (int count = 0; count <= resicle; count++)
        {
            yield return new WaitForSeconds(Switch_Time);
            D_Light.intensity = 100;
            Object_1.SetActive(false);
            Object_2.SetActive(true);
            postProcessVolume.profile.GetSetting<Bloom>().intensity.value = 20.0f;
            yield return new WaitForSeconds(0.005f);
            postProcessVolume.profile.GetSetting<Bloom>().intensity.value = 2.0f;
            yield return new WaitForSeconds(Switch_Time);
            D_Light.intensity = 10;
            Object_1.SetActive(true);
            Object_2.SetActive(false);
        }
    }
}
