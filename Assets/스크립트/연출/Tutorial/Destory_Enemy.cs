using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory_Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, 10.0f);
    }
}
