using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Rendering_Color : MonoBehaviour
{
    [SerializeField] private Renderer renderer;
    public Color text_Color;
    // Start is called before the first frame update
    void Awake()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = text_Color;
    }
}
