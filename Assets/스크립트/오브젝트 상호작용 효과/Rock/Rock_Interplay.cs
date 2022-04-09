using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Interplay : MonoBehaviour , I_Interplay_effect
{
    AudioSource Audio;
    private void Awake()
    {
        //해당 컴포넌트를 Interplay_machice에 참조시킨다.
        GetComponent<Interplay_machice>().SetInterplay(this);
        Audio = GetComponent<AudioSource>();
    }

    public void Effect() 
    {
        GameObject.Find("Player").GetComponent<Fire_Bullte>().add_Count_Bullte(1);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Object_Sound_Clip>())
        {
            Debug.Log("Play Sound");
            Audio.PlayOneShot(collision.gameObject.GetComponent<Object_Sound_Clip>().Collider_Sound, PlayerPrefs.GetFloat("E_vol_base"));
        }
    }
    
}
