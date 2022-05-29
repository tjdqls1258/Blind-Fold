using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4_01_start : MonoBehaviour
{
    private AudioSource audio;
    [SerializeField] private AudioClip Clip_01, Clip_02;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag=="Player")
        {
            audio.PlayOneShot(Clip_01);
            StartCoroutine(Play_Clip_02());
            GetComponent<Collider>().enabled = false;
        }
    }

    IEnumerator Play_Clip_02()
    {
        for(int count = 0; count < 6; count++)
        {
            yield return new WaitForSeconds(0.4f);
            audio.PlayOneShot(Clip_02);
        }
    }
}
