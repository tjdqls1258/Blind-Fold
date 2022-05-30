using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4_03_ATK : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.gameObject.GetComponent<Player_Is_Die>().Is_Die(gameObject);
        }
    }
}
