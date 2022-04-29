using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 연출2탄 : MonoBehaviour
{
    [SerializeField] GameObject[] 짜란;
    [SerializeField] GameObject 빛이_있으라;
    AudioSource audioSource;
    int count = 30;
    [SerializeField] bool Is_Atvie = false;

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
        int num = 0;
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSeconds(0.05f);
            if (i%2 == 1)
            {
                num = Random.Range(0, 짜란.Length);
                짜란[num].SetActive(true);
                Is_Atvie = true;
                StartCoroutine(Set_Ative_OFF(num));
            }
            if (i % 3 == 1)
            {
                빛이_있으라.SetActive(true);
            }
            else
            {
                빛이_있으라.SetActive(false);
            }
        }
    }

    IEnumerator Set_Ative_OFF(int num)
    {
        yield return new WaitForSeconds(0.5f);
        짜란[num].SetActive(false);
    }
}
