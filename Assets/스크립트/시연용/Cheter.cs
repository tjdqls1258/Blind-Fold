using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheter : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private Light D_Light;

    [SerializeField] GameObject Teleport;
    
    private GameObject[] AI;
    // Start is called before the first frame update
    void Awake()
    {
        AI = GameObject.FindGameObjectsWithTag("AI");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            KeyUp();
            Staminer_Infinete();        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Kill_AI();
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            ����_������();
        }
        if(Input.GetKey(KeyCode.Alpha4))
        {
            telnext();
        }
    }

    private void KeyUp()
    {
        Player.GetComponent<Player_Move>().collect_key = 99;
    }

    private void Kill_AI()
    {
        for(int count = 0; count < AI.Length; count++)
        {
            AI[count].SetActive(false);
        }
    }

    private void ����_������()
    {
        D_Light.intensity = 1.0f;
    }

    private void Staminer_Infinete()
    {
        Player.GetComponent<Player_Move>().Stamina_Gage = 99999.0f;
    }

    private void telnext()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        Player.transform.position = new Vector3(Teleport.transform.position.x, Teleport.transform.position.y, Teleport.transform.position.z);
        Player.transform.rotation = Teleport.transform.rotation;
    }
}
