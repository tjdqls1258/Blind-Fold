using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Foot_Sound : MonoBehaviour
{
    [SerializeField] AudioSource Foot_Source;
    [SerializeField] AudioClip Foot_Sound_Clip;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        Foot_Source.PlayOneShot(Foot_Sound_Clip);
    }
}
