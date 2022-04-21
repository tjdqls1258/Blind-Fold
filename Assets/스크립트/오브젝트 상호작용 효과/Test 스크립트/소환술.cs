using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 소환술 : MonoBehaviour
{
    [SerializeField] GameObject 따란;
    bool Is_Atvie = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!Is_Atvie)
        {
            StartCoroutine(Set_Ative_On());
        }
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
