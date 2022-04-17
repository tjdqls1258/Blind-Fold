// SimpleSonarShader scripts and shaders were written by Drew Okenfuss.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSonarShader_Object : MonoBehaviour
{
    [SerializeField] private float Ring_Speed = 3.0f;
    [SerializeField] private float Ring_Range = 1.0f;
    // All the renderers that will have the sonar data sent to their shaders.
    private Renderer[] ObjectRenderers;

    // Throwaway values to set position to at the start.
    private static readonly Vector4 GarbagePosition = new Vector4(-5000, -5000, -5000, -5000);

    // The number of rings that can be rendered at once.
    // Must be the samve value as the array size in the shader.
    private static int QueueSize = 5;

    // Queue of start positions of sonar rings.
    // The xyz values hold the xyz of position.
    // The w value holds the time that position was started.
    private static Queue<Vector4> positionsQueue = new Queue<Vector4>(QueueSize);

    // Queue of intensity values for each ring.
    // These are kept in the same order as the positionsQueue.
    private static Queue<float> intensityQueue = new Queue<float>(QueueSize);

    // Make sure only 1 object initializes the queues.
    private static bool NeedToInitQueues = true;

    // Will call the SendSonarData for each object.
    private delegate void Delegate();
    private static Delegate RingDelegate;

    private Collider[] Get_Object;
    private float Timer = 0;
    private float raidus = 0;
    private void Start()
    {
        // Get renderers that will have effect applied to them
        ObjectRenderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer r in ObjectRenderers)
        {
            r.material.SetFloat("_RingSpeed", Ring_Speed);
            r.material.SetFloat("_RingIntensityScale", Ring_Range);
        }

        if (NeedToInitQueues)
        {
            NeedToInitQueues = false;
            // Fill queues with starting values that are garbage values
            for (int i = 0; i < QueueSize; i++)
            {
                positionsQueue.Enqueue(GarbagePosition);
                intensityQueue.Enqueue(-5000f);
            }
        }

        // Add this objects function to the static delegate
        RingDelegate += SendSonarData;
    }

    /// <summary>
    /// Starts a sonar ring from this position with the given intensity.
    /// </summary>
    public void StartSonarRing(Vector4 position, float intensity)
    {
        // Put values into the queue
        position.w = Time.timeSinceLevelLoad;
        positionsQueue.Dequeue();
        positionsQueue.Enqueue(position);

        intensityQueue.Dequeue();
        intensityQueue.Enqueue(intensity);

        RingDelegate();
    }

    /// <summary>
    /// Sends the sonar data to the shader.
    /// </summary>
    private void SendSonarData()
    {
        // Send updated queues to the shaders
        foreach (Renderer r in ObjectRenderers)
        {
            r.material.SetVectorArray("_hitPts", positionsQueue.ToArray());
            r.material.SetFloatArray("_Intensity", intensityQueue.ToArray());
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Start sonar ring from the contact point
        if(collision.transform.tag == "Player" || collision.transform.tag == "AI" || transform.tag == "AI")
        {
            return;
        }
        StartCoroutine(Sonar_agin(collision));
        StartCoroutine(Serch_Object(collision.gameObject.transform.position, collision.impulse.magnitude / 10.0f));
    }

    private IEnumerator Serch_Object(Vector4 pos, float Power)
    {
        Debug.Log(pos);
        Timer = 0;
        raidus = 0;
        while (Timer < (Power / 3))
        {
            Timer += 0.1f;
            raidus = Timer * Ring_Speed;
            if (raidus >= Power)
            {
                raidus = Power;
            }
            Get_Object = Physics.OverlapSphere(pos, raidus);
            for (int count = 0; count < Get_Object.Length; count++)
            {
                if (Get_Object[count].gameObject.GetComponent<Emission_Effect>() && !Get_Object[count].gameObject.GetComponent<Emission_Effect>().Is_Emission)
                {
                    Get_Object[count].gameObject.GetComponent<Emission_Effect>().Emission_This_Object(3.0f);
                }
            }
            yield return null;
            //yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator Sonar_agin(Collision collision)
    {
        StartSonarRing(collision.contacts[0].point, collision.impulse.magnitude / 10.0f);
        yield return new WaitForSeconds(0.2f);
        StartSonarRing(collision.contacts[0].point, collision.impulse.magnitude / 10.0f);
    }

    private void OnDestroy()
    {
        RingDelegate -= SendSonarData;
    }

}
