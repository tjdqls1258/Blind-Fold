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

    [SerializeField] private float stamina_percent;
    private bool isecho = true;

    [Header("임시 변수")]
    [SerializeField] private float echocool;

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
        if (Input.GetKeyDown(KeyCode.Q) && isecho
            && (this.GetComponent<Player_Move>().Stamina_Gage >= (this.GetComponent<Player_Move>().Max_Stamina_Gage * 0.25f)))
        {
            isecho = false;
            this.GetComponent<Player_Move>().stamina_pause = true;
            stamina_percent = this.GetComponent<Player_Move>().get_stamina_percent();
            this.GetComponent<Player_Move>().Stamina_Gage -= (this.GetComponent<Player_Move>().Max_Stamina_Gage * 0.25f);
            if (this.GetComponent<Player_Move>().Stamina_Gage < 0)
            {
                this.GetComponent<Player_Move>().Stamina_Gage = 0;
            }

            relay_Sound.Serch_AI_And_Relay_Sound(Echo_Hear_Distance_Power * stamina_percent);
            StartCoroutine(Sonar_agin(transform.position, Echo_Power * stamina_percent));
            StartCoroutine(Echo_cooltime());
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
                yield return new WaitForSeconds(0.5f * stamina_percent);
            }
            Sonar_Is_Start = false;
        }
    }

    IEnumerator Echo_cooltime()
    {
        yield return new WaitForSeconds(echocool);
        isecho = true;
        this.GetComponent<Player_Move>().stamina_pause = false;
    }
}
