using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interplay_machice : MonoBehaviour
{
    [SerializeField] I_Interplay_effect this_Interplay_effect;
    public string Exposition;

    public void Interplay()
    {
        this_Interplay_effect.Effect();
    }

    public void SetInterplay(I_Interplay_effect state)
    {
        //I_Interplay_effect를 설정해준다.
        this_Interplay_effect = state;
    }
}
