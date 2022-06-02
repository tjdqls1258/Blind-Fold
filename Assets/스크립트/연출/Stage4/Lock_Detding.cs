using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock_Detding : MonoBehaviour
{
    [SerializeField] private Animator Lock_Anim;
    [SerializeField] private GameObject Surprise;
    private bool Is_Coll = false;

    private void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            Surprise.transform.LookAt(other.transform.position + (other.transform.up * 0.8f));
            if (Lock_Anim.GetBool("Is_Open") && !Is_Coll)
            {
                Is_Coll = true;

                StartCoroutine(shako(other));
            }
        }
    }

    IEnumerator shako(Collider other)
    {
        yield return new WaitForSeconds(0.8f);

        Surprise.SetActive(true);
        Surprise.transform.position = other.transform.position + (other.transform.forward * 3.5f) + (other.transform.up * 0.8f);
    }
}//511