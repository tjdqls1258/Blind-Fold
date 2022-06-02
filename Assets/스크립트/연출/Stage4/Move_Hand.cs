using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Hand : MonoBehaviour
{
    void Update()
    {
        transform.position += transform.forward * 0.01f;
        Destroy(gameObject, 1.0f);
    }
}