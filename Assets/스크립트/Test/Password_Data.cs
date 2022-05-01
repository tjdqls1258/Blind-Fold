using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Password_Data : MonoBehaviour
{
    public int Pass_Num;
    [SerializeField] private TextMesh text; 
    void Start()
    {
        text = GetComponent<TextMesh>();
        Pass_Num = Random.Range(0, 9);
        text.text = Pass_Num.ToString();
    }
}
