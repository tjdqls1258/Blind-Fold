using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathfinder : MonoBehaviour
{
    [SerializeField] GameObject p_finder;

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
            p_finder.SetActive(true);
        }
    }
}
