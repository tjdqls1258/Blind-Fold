using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Animation_Speed : MonoBehaviour
{
    [SerializeField] private float Animation_Speed = 1.0f;

    private void Awake()
    {
        GetComponent<Animator>().speed = Animation_Speed;
    }
}
