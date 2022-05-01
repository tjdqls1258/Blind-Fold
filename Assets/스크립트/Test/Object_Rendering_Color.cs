using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Rendering_Color : MonoBehaviour
{
    [SerializeField] private Renderer renderer;
    [SerializeField] private Color text_Color;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = text_Color;
    }
}
