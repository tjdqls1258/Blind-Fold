using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4_04_start : MonoBehaviour
{
    [SerializeField] private GameObject Key, Ghost, Blood;
    private Animator anim;
    private bool Is_Coll = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(!Key && !Is_Coll)
            {
                Is_Coll = true;
                StartCoroutine(Set_Ative());
            }
        }
    }

    IEnumerator Set_Ative()
    {
        Ghost.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        Blood.SetActive(true);

        yield return new WaitForSeconds(5.0f);
        Ghost.SetActive(false);
        Blood.SetActive(false);

    }
}
