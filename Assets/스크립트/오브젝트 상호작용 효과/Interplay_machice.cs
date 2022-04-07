using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interplay_machice : MonoBehaviour
{
    [SerializeField] I_Interplay_effect this_Interplay_effect;
    public string Exposition;
    public bool Is_Emission = false;

    public void Interplay()
    {
        this_Interplay_effect.Effect();
    }

    public void SetInterplay(I_Interplay_effect state)
    {
        //I_Interplay_effect를 설정해준다.
        this_Interplay_effect = state;
    }

    public void Emission_This_Object(float Wait_Time)
    {
        Is_Emission = true;
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
                GetComponentInChildren<Renderer>().material.SetFloat("_Emission", Fade_Out);
            }
        }

        if (GetComponent<Renderer>())
        {
            GetComponent<Renderer>().material.SetFloat("_Emission", 0.0f);
        }
        else
        {
            GetComponentInChildren<Renderer>().material.SetFloat("_Emission", 0.0f);
        }
        Is_Emission = false;
    }
}
