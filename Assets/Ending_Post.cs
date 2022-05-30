using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Ending_Post : MonoBehaviour
{
    PostProcessVolume PostVol;

    private void Awake()
    {
        PostVol = GetComponent<PostProcessVolume>();
        StartCoroutine(Ending());
    }
    IEnumerator Ending()
    {
        yield return new WaitForSeconds(1.0f);
        PostVol.profile.GetSetting<DepthOfField>().focalLength.value = 0.0f;
    }
}
