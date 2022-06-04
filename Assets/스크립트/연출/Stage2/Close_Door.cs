using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close_Door : MonoBehaviour
{
    [SerializeField] private GameObject Door;
    [SerializeField] private GameObject Light;
    private bool Is_Ative= false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player" && !Is_Ative)
        {
            Debug.Log("!!");
            Light.SetActive(true);
            Door.GetComponent<Door_InterPlay>().Effect();
            Door.GetComponent<Door_InterPlay>().Is_Lock = true;
            Is_Ative = true;
        }
    }
}
