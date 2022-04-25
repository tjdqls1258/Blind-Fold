using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Echo_Enemy : MonoBehaviour
{
    [SerializeField] private GameObject map_parent;
    [SerializeField] private float Delay_Time = 2;
    [SerializeField] private float Echo_Power;
    [SerializeField] private float _Time = 0;
    [SerializeField] private float Max_Create_Echo_Player_And_This_Distance = 30.0f;
    GameObject Player;
    private void Awake()
    {
        Player = GameObject.Find("Player");
    }
    void Update()
    {
        if (Vector3.Distance(Player.transform.position, transform.position) < Max_Create_Echo_Player_And_This_Distance)
        {
            _Time += Time.deltaTime;
            if (_Time >= Delay_Time)
            {
                map_parent.GetComponent<SimpleSonarShader_Parent>().StartSonarRing(transform.position, Echo_Power);
                _Time = 0;
            }
        }
    }
}