using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce_Awake : MonoBehaviour
{
    [SerializeField] private float Power = 1000.0f;
    private void Awake()
    {
        GetComponent<Rigidbody>().AddForce(transform.right * Power);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.GetComponent<Object_Sound_Clip>())
        {
            GetComponent<AudioSource>().PlayOneShot(collision.transform.GetComponent<Object_Sound_Clip>().Collider_Sound);
        }
    }
}
