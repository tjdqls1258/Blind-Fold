using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4_03_ATK : MonoBehaviour
{
    [SerializeField] private GameObject Die_Player_anim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.gameObject.GetComponent<Player_Is_Die>().Is_Die();
            Die_Player_anim.SetActive(true);
        }
    }
}
