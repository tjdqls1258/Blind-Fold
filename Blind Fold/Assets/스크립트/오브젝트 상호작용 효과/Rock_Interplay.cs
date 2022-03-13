using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Interplay : MonoBehaviour , I_Interplay_effect
{
    private void Awake()
    {
        //해당 컴포넌트를 Interplay_machice에 참조시킨다.
        GetComponent<Interplay_machice>().SetInterplay(this);
    }

    public void Effect() 
    {
        GameObject.Find("Player").GetComponent<Fire_Bullte>().add_Count_Bullte(1);
        Destroy(gameObject);
    }
}
