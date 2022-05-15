using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Post_Bloom_Con : MonoBehaviour
{
    PostProcessVolume post;
    GameObject Player;
    // Start is called before the first frame update
    void Awake()
    {
        post = GetComponent<PostProcessVolume>();
        Player = GameObject.Find("Player");
        StartCoroutine(Change_Vaule_To_Bloom());
    }
    IEnumerator Change_Vaule_To_Bloom()
    {
        while (post.profile.GetSetting<Bloom>().intensity.value >= 0.0f)
        {
            post.profile.GetSetting<Bloom>().intensity.value -= Time.deltaTime * 50.0f;
            yield return null;
        }
        post.profile.GetSetting<Bloom>().active = false;
        Player.GetComponentInChildren<PostProcessVolume>().profile.GetSetting<Bloom>().active = false;
        yield return null;
    }
}
