// SimpleSonarShader scripts and shaders were written by Drew Okenfuss.

using System.Collections;
using UnityEngine;

public class SimpleSonarShader_ExampleCollision : MonoBehaviour
{
    [SerializeField] private uint Count_Cycle = 4;
    [SerializeField] private float power = 10;
    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
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
        SimpleSonarShader_Parent parent = GetComponentInParent<SimpleSonarShader_Parent>();
        for (int currnet = 0; currnet < Count_Cycle; currnet++)
        {
            Debug.Log(currnet);
            if (parent) parent.StartSonarRing(pos, power);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
