using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emission_Hint : MonoBehaviour
{
    public bool Is_Emission = false;
    private Renderer[] ObjectRenderers;

    [SerializeField] private Renderer renderer;
    [SerializeField] private Color text_Color;

    void Awake()
    {
        renderer = GetComponent<Renderer>();
        text_Color = GetComponent<Object_Rendering_Color>().text_Color;
    }

    public void Show_The_Hint(float Wait_Time)
    {
        if (!Is_Emission)
        {
            Is_Emission = true;

            if (GetComponent<Renderer>())
            {
                GetComponent<Renderer>().material.SetColor("_Color", new Color(text_Color.r, text_Color.g, text_Color.b, 1.0f));
            }

            StartCoroutine(Return_Emission(Wait_Time));
        }
    }
    private IEnumerator Return_Emission(float Wait_Time)
    {
        yield return new WaitForSeconds(Wait_Time);
        float Fade_Out = 1.0f;
        while (Fade_Out > 0)
        {
            yield return null;
            Fade_Out -= Time.deltaTime;
            if (GetComponent<Renderer>())
            {
                GetComponent<Renderer>().material.SetColor("_Color", new Color(text_Color.r, text_Color.g, text_Color.b, Fade_Out));
            }
        }

        if (GetComponent<Renderer>())
        {
            GetComponent<Renderer>().material.SetColor("_Color", new Color(text_Color.r, text_Color.g, text_Color.b, 0.0f));
        }
        Is_Emission = false;
    }
}
