using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interplay_Object : MonoBehaviour
{
    private RaycastHit hit;
    private Ray ray;
    [SerializeField] private float Ray_distance;
    [SerializeField] private Text exposition_text;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {    
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Ray_distance))
        {
            if (hit.transform.gameObject.GetComponent<Interplay_machice>())
            {
                Interplay_machice interplay = hit.transform.gameObject.GetComponent<Interplay_machice>();
                //설명 보이기
                exposition_text.text = interplay.Exposition;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interplay.Interplay();
                    //각 상호작용마다 Interplay_machice.cs가 필요함
                    //각 오브젝트의 상호작용 효과 기능은 I_Interplay_effect를 상속받음.
                }
            }
            else
            {
                exposition_text.text = "";
            }
        }
        else
        {
            exposition_text.text = "";
        }
    }

}
