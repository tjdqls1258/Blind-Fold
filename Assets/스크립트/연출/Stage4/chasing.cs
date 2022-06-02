using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasing : MonoBehaviour
{
    [SerializeField] GameObject chaser;
    [SerializeField] GameObject Player_head;

    private bool isactive = false;

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
        if(other.transform.tag == "Player" && isactive == false)
        {
            chaser.SetActive(true);
            Player_head.GetComponent<Interplay_Object>().enabled = false;
            isactive = true;
        }
    }
}
