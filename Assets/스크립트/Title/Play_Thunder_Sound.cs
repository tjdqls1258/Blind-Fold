using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Thunder_Sound : MonoBehaviour
{
    AudioSource[] sounds;
    private void Awake()
    {
        sounds = gameObject.GetComponentsInChildren<AudioSource>();
    }

    public void Thunder_Sound_Play()
    {
        sounds[Random.Range(0, sounds.Length)].Play();
    }
}
