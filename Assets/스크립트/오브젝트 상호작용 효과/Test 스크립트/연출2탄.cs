using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 연출2탄 : MonoBehaviour
{
    [SerializeField] GameObject 따란;
    [SerializeField] GameObject 빛이_있으라;
    AudioSource audioSource;
    int count = 20;
    bool Is_Atvie = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!Is_Atvie)
            {
                StartCoroutine(Set_Ative_On());
                audioSource.Play();
            }
        }
    }

    IEnumerator Set_Ative_On()
    {
        for(int i = 0; i < count; i++)
        {
            yield return new WaitForSeconds(0.05f);
            if (i == 10)
            {
                따란.SetActive(true);
                Is_Atvie = true;
                StartCoroutine(Set_Ative_OFF());
            }
            if (i % 2 == 1)
            {
                빛이_있으라.SetActive(true);
            }
            else
            {
                빛이_있으라.SetActive(false);
            }
        }
        Destroy(gameObject);
    }

    IEnumerator Set_Ative_OFF()
    {
        yield return new WaitForSeconds(0.5f);
        따란.SetActive(false);
    }
}
