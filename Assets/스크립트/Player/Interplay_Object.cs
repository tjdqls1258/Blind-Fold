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
        
        if (Physics.Raycast(ray, out hit, Ray_distance, ((-1)-(1<<8))))
        {
            if (hit.transform.gameObject.GetComponent<Interplay_machice>())
            {
                Interplay_machice interplay = hit.transform.gameObject.GetComponent<Interplay_machice>();
                //설명 보이기
                exposition_text.text = interplay.Exposition;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interplay.Interplay();
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
