using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostmove : MonoBehaviour
{
    [SerializeField] GameObject destination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination.transform.position, Time.deltaTime * 10.0f);
    }
}
