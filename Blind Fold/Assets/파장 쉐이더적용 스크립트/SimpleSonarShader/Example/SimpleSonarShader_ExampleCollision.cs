// SimpleSonarShader scripts and shaders were written by Drew Okenfuss.

using System.Collections;
using UnityEngine;


public class SimpleSonarShader_ExampleCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Start sonar ring from the contact point
        StartCoroutine(Sonar_agin(collision));
    }
    IEnumerator Sonar_agin(Collision collision)
    {
        SimpleSonarShader_Parent parent = GetComponentInParent<SimpleSonarShader_Parent>();
        if (parent) parent.StartSonarRing(collision.contacts[0].point, collision.impulse.magnitude / 10.0f);
        yield return new WaitForSeconds(0.2f);
        if (parent) parent.StartSonarRing(collision.contacts[0].point, collision.impulse.magnitude / 10.0f);
    }
}
