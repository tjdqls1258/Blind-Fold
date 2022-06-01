using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage01_01 : MonoBehaviour
{
    [SerializeField] private GameObject Door;
    [SerializeField] private GameObject Zombie;
    private bool Is_Play = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !Is_Play)
        {
            Is_Play = true;
            GetComponent<Animator>().SetBool("Is_Coll", true);
            Zombie.SetActive(true);
            StartCoroutine(Start_01());
        }
    }

    IEnumerator Start_01()
    {
        yield return new WaitForSeconds(1.6f);
        Door.GetComponent<AudioSource>().Play();
        Door.GetComponent<Animator>().SetBool("SwitchDoor", true);
    }
}
