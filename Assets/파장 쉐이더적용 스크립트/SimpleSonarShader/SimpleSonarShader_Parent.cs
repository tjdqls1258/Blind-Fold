// SimpleSonarShader scripts and shaders were written by Drew Okenfuss.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSonarShader_Parent : MonoBehaviour
{
    [Header("Ring Setting")]
    [SerializeField] private float Ring_Speed = 3.0f;
    [SerializeField] private float Ring_Range = 1.0f;
    // All the renderers that will have the sonar data sent to their shaders.
    private Renderer[] ObjectRenderers;

    // Throwaway values to set position to at the start.
    private static readonly Vector4 GarbagePosition = new Vector4(-5000, -5000, -5000, -5000);

    // The number of rings that can  // Queue of start positions of sonar rings.
    // The xyz values hold the xyz of position.
    // The w value holds the time that position was started.be rendered at once.
    // Must be the samve value as the array size in the shader.
    private static int QueueSize = 20;  //파장의 반지름(유지 시간) 

    // 파동의 시작 위치 대기열.
    // xyz 값은 위치의 xyz를 유지합니다.
    // w 값은 위치가 시작된 시간을 보유합니다
    private Queue<Vector4> positionsQueue = new Queue<Vector4>(QueueSize);
    // 각 링에 대한 강도 값의 대기열입Get renderers that will have effect applied to them니다.
    // 이것은 positionQueue와 같은 순서로 유지됩니다.
    private Queue<float> intensityQueue = new Queue<float>(QueueSize);


    private void Start()
    {
        //효과를 적용할 렌더러 가져오기
        ObjectRenderers = GetComponentsInChildren<Renderer>();

        // Fill queues with starting values that are garbage values //큐 초기화
        foreach (Renderer r in ObjectRenderers)
        {
            r.material.SetFloat("_RingSpeed", Ring_Speed);
            r.material.SetFloat("_RingIntensityScale", Ring_Range);
        }

        for (int i = 0; i < QueueSize; i++)
        {
            positionsQueue.Enqueue(GarbagePosition);
            intensityQueue.Enqueue(-5000f);
        }
    }

    /// <summary>
    /// Starts a sonar ring from this position with the given intensity.
    /// </summary>
    public void StartSonarRing(Vector4 position, float intensity) //위치에서 시작
    {
        // Put values into the queue
        position.w = Time.timeSinceLevelLoad;
        positionsQueue.Dequeue();
        positionsQueue.Enqueue(position);

        intensityQueue.Dequeue();
        intensityQueue.Enqueue(intensity);

        // Send updated queues to the shaders
        foreach (Renderer r in ObjectRenderers)
        {
            if (r)
            {
                //r.material.SetVectorArray("_ObjectPos", positionsQueue.ToArray());
                r.material.SetVectorArray("_hitPts", positionsQueue.ToArray());
                r.material.SetFloatArray("_Intensity", intensityQueue.ToArray());
            }
        }
        StartCoroutine(Serch_Object(position, intensity));
    }

    private IEnumerator Serch_Object(Vector4 pos, float Power)
    {
        float Timer = 0;
        float raidus = 0;
        while (Timer < (Power / 3))
        {
            Timer += Time.deltaTime;
            raidus = Timer * Ring_Speed;
            if (raidus >= Power)
            {
                raidus = Power;
            }
            Collider[] Get_Object = Physics.OverlapSphere(pos, raidus);

            for (int count = 0; count < Get_Object.Length; count++)
            {
                if (Get_Object[count].gameObject.GetComponent<Interplay_machice>() && !Get_Object[count].gameObject.GetComponent<Interplay_machice>().Is_Emission)
                {
                    Get_Object[count].gameObject.GetComponent<Interplay_machice>().Emission_This_Object(3.0f);
                }
            }
            yield return null;
        }
    }
}
