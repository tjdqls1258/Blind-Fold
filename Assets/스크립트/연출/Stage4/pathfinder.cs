using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathfinder : MonoBehaviour
{
    [SerializeField] GameObject p_finder;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            p_finder.SetActive(true);
        }
    }
}
