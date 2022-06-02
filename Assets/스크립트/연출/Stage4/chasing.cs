using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasing : MonoBehaviour
{
    [SerializeField] GameObject chaser;
    [SerializeField] GameObject Player_head;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            chaser.SetActive(true);
            Player_head.GetComponent<Interplay_Object>().enabled = false;


        }
    }
}
