using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseEvent : MonoBehaviour
{
    [SerializeField] private Text btn_text;

    public void OnMouseEnter()
    {
        btn_text.GetComponent<Text>().fontStyle = FontStyle.Italic;
    }

    public void OnMouseExit()
    {
        btn_text.GetComponent<Text>().fontStyle = FontStyle.Bold;
    }
}
