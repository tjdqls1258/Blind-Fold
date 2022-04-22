using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 소환술 : MonoBehaviour
{
    [SerializeField] GameObject 따란;
    [SerializeField] Light light;
    bool Is_Atvie = false;
    [SerializeField] bool Is_Light = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!Is_Light)
        {
            StartCoroutine(Set_Light_Switch());
        }
        if (!Is_Atvie)
        {
            StartCoroutine(Set_Ative_On());
        }
    }

    IEnumerator Set_Light_Switch()
    {
        Is_Light = true;
        while (light.intensity <= 0.5f)
        {
            light.intensity += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        while (light.intensity >= 0.1f)
        {
            light.intensity -= Time.deltaTime;
            yield return null;
        }
        light.intensity = 0;
        Is_Light = false;
    }

    IEnumerator Set_Ative_On()
    {
        yield return new WaitForSeconds(0.5f);
        따란.SetActive(true);
        Is_Atvie = true;
        StartCoroutine(Set_Ative_OFF());
    }

    IEnumerator Set_Ative_OFF()
    {
        yield return new WaitForSeconds(2.0f);
        따란.SetActive(false);
    }
}
