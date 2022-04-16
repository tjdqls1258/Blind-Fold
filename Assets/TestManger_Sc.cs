using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManger_Sc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 30 == 0)
        {
            System.GC.Collect();
        }
    }
}
