using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Relay_Sound))]
public class Create_Echo : MonoBehaviour
{
    [Header("최상위 맵 오브젝트")]
    [SerializeField] private GameObject map_parent;
    [Header("Echo 파워 관련")]
    [SerializeField] private float Echo_Power = 0.0f;
    [SerializeField] private float Echo_Hear_Distance_Power = 50.0f;
    [Header("반복 횟수")]
    [SerializeField] private uint Count_Cycle = 1;
    private bool Sonar_Is_Start = false;
    Relay_Sound relay_Sound;
    private void Start()
    {
        relay_Sound = gameObject.GetComponent<Relay_Sound>();
    }

    private void Awake()
    {
        Sonar_Is_Start = false;
    }
    private void OnEnable()
    {
        Sonar_Is_Start = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            relay_Sound.Serch_AI_And_Relay_Sound(Echo_Hear_Distance_Power);
            StartCoroutine(Sonar_agin(transform.position, Echo_Power));
        }
    }

    IEnumerator Sonar_agin(Vector3 pos, float power)
    {
        if (!Sonar_Is_Start)
        {
            Sonar_Is_Start = true;
            SimpleSonarShader_Parent parent = map_parent.GetComponentInParent<SimpleSonarShader_Parent>();
            for (int currnet = 0; currnet < Count_Cycle; currnet++)
            {
                if (parent) parent.StartSonarRing(pos, power);
                yield return new WaitForSeconds(0.5f);
            }
            Sonar_Is_Start = false;
        }
    }
}
