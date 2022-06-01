using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4_02_start : MonoBehaviour
{
    private Vector3 distance;
    private RaycastHit hit;
    private Ray ray;

    private AudioSource audio;
    private bool Is_Coll = false;

    [SerializeField] private GameObject Supersize_Object;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 10, ((-1) - (1 << 8) - (1 << 7))))
            {
                if (hit.transform.tag == "Directing" && !Is_Coll)
                {
                    Is_Coll = true;
                    Supersize_Object.SetActive(true);
                    audio.Play();
                }
            }
        }
    }
}
