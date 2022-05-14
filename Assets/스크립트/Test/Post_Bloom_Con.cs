using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Post_Bloom_Con : MonoBehaviour
{
    PostProcessVolume post;
    // Start is called before the first frame update
    void Awake()
    {
        post = GetComponent<PostProcessVolume>();
        StartCoroutine(Change_Vaule_To_Bloom());
    }
    IEnumerator Change_Vaule_To_Bloom()
    {
        while (post.profile.GetSetting<Bloom>().intensity.value >= 0.0f)
        {
            post.profile.GetSetting<Bloom>().intensity.value -= Time.deltaTime * 50.0f;
            yield return null;
        }
        yield return null;
    }
}
