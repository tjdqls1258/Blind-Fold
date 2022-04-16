// SimpleSonarShader scripts and shaders were written by Drew Okenfuss.

using System.Collections;
using UnityEngine;

public class SimpleSonarShader_ExampleCollision : MonoBehaviour
{
    [SerializeField] private uint Count_Cycle = 3;
    [SerializeField] private float power = 10;
    [SerializeField] private float tick = 0.5f;
    private bool Sonar_Is_Start = false;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player" || collision.transform.tag == "AI")
        {
            return;
        }
        // Start sonar ring from the contact point
        if (collision.transform.GetComponent<Relay_Sound>())
        {
            StartCoroutine(Sonar_agin(collision.contacts[0].point, collision.transform.GetComponent<Relay_Sound>().Sound_Power));
        }
        else
        {
            StartCoroutine(Sonar_agin(collision.contacts[0].point, power));
        }
    }
    IEnumerator Sonar_agin(Vector3 pos, float power)
    {
        if (!Sonar_Is_Start)
        {
            Sonar_Is_Start = true;
            SimpleSonarShader_Parent parent = GetComponentInParent<SimpleSonarShader_Parent>();
            for (int currnet = 0; currnet < Count_Cycle; currnet++)
            {
                if (parent) parent.StartSonarRing(pos, power);
                yield return new WaitForSeconds(tick);
            }
            Sonar_Is_Start = false;
        }
    }
}
