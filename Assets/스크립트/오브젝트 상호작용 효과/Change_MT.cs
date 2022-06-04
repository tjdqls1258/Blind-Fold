using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_MT : MonoBehaviour
{
    private void Awake()
    {
        if (GetComponent<Renderer>())
        {
            GetComponent<Renderer>().material.SetFloat("_Emission", 0.01f);
        }
    }
}
