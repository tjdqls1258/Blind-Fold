using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Interplay : MonoBehaviour , I_Interplay_effect
{
    AudioSource Audio;
    float Sound_Value;
    [SerializeField] bool Is_Map = false;

    private void Awake()
    {
        //해당 컴포넌트를 Interplay_machice에 참조시킨다.
        GetComponent<Interplay_machice>().SetInterplay(this);
        Audio = GetComponent<AudioSource>();
        Sound_Value = PlayerPrefs.GetFloat("E_vol_base",1.0f);
    }

    public void Effect() 
    {
        if(GameObject.Find("Player").GetComponent<Fire_Bullte>().add_Count_Bullte())
        {
            int index = gameObject.name.IndexOf("(Clone)");
            if (index > 0)
            {
                gameObject.name = gameObject.name.Substring(0, index);
            }

            GameObject.Find("Player").GetComponent<Fire_Bullte>().Bullte.Enqueue(Resources.Load<GameObject>("Rock/" + gameObject.name));
            //Instantiate(this.gameObject, Vector3.zero, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Object_Sound_Clip>() && !Is_Map)
        {
            Audio.PlayOneShot(collision.gameObject.GetComponent<Object_Sound_Clip>().Collider_Sound, Sound_Value);
        }
    }
    
}
