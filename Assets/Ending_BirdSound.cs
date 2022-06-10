using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending_BirdSound : MonoBehaviour
{
    private AudioSource audio;
    [SerializeField] private List<AudioClip> sound;
    public int Sound;
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        StartCoroutine(AudioPlayer());
    }

    private IEnumerator AudioPlayer()
    {
        Sound = Random.Range(0, sound.Count);
        float time = Random.Range(0.3f, 1.0f);
        while (true)
        {
            audio.PlayOneShot(sound[Sound]);
            yield return new WaitForSeconds(time);
            Sound = Random.Range(0, sound.Count);
            time = Random.Range(0.3f, 1.0f);
        }
    }
}
