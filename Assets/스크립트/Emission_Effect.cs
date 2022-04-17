using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emission_Effect : MonoBehaviour
{
    public bool Is_Emission = false;
    private Renderer[] ObjectRenderers;

    private void Awake()
    {
        Is_Emission = false;
        ObjectRenderers = GetComponentsInChildren<Renderer>();

        if (GetComponent<Renderer>())
        {
            GetComponent<Renderer>().material.SetFloat("_Emission", 0.0f);
        }
        else
        {
            foreach (Renderer r in ObjectRenderers)
            {
                r.material.SetFloat("_Emission", 0.0f);
            }
        }
    }
    public void Emission_This_Object(float Wait_Time)
    {
        Is_Emission = true;

        foreach (Renderer r in ObjectRenderers)
        {
            r.material.SetFloat("_Emission", 0.5f);
        }

        if (GetComponent<Renderer>())
        {
            GetComponent<Renderer>().material.SetFloat("_Emission", 0.5f);
        }
        else
        {
            GetComponentInChildren<Renderer>().material.SetFloat("_Emission", 0.5f);
        }
        StartCoroutine(Return_Emission(Wait_Time));
    }

    private IEnumerator Return_Emission(float Wait_Time)
    {
        yield return new WaitForSeconds(Wait_Time);
        float Fade_Out = 0.5f;
        while (Fade_Out > 0)
        {
            yield return null;
            Fade_Out -= Time.deltaTime;
            if (GetComponent<Renderer>())
            {
                GetComponent<Renderer>().material.SetFloat("_Emission", Fade_Out);
            }
            else
            {
                foreach (Renderer r in ObjectRenderers)
                {
                    r.material.SetFloat("_Emission", Fade_Out);
                }
            }


        }

        if (GetComponent<Renderer>())
        {
            GetComponent<Renderer>().material.SetFloat("_Emission", 0.0f);
        }
        else
        {
            foreach (Renderer r in ObjectRenderers)
            {
                r.material.SetFloat("_Emission", 0.0f);
            }
        }
        Is_Emission = false;
    }
}
