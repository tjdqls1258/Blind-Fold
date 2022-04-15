using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Interplay : MonoBehaviour , I_Interplay_effect
{
    private void Awake()
    {
        GetComponent<Interplay_machice>().SetInterplay(this);
    }

    public void Effect()
    {
        GameObject.Find("Player").GetComponent<Player_Move>().collect_key += 1;
        Destroy(gameObject);
    }
}
