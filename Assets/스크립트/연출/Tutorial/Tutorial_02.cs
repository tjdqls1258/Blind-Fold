using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_02 : MonoBehaviour
{
    [SerializeField] private GameObject Rock;
    [SerializeField] private GameObject Say;
    [SerializeField] private GameObject Key;
    [SerializeField] private GameObject Blood;
    [SerializeField] private Kino.AnalogGlitch Head;
    private bool Is_Coll = false;

    private void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            if (!Rock && !Is_Coll)
            {
                Is_Coll = true;
                Say.SetActive(false);
                StartCoroutine(Noice_Head());
                Key.SetActive(true);
                Blood.SetActive(true);
            }
        }
    }

    IEnumerator Noice_Head()
    {
        Head.verticalJump = 1.0f;
        yield return new WaitForSeconds(0.5f);
        Head.verticalJump = 0.0f;
    }
}
