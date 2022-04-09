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
                //���� ���̱�
                exposition_text.text = interplay.Exposition;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interplay.Interplay();
                    //�� ��ȣ�ۿ븶�� Interplay_machice.cs�� �ʿ���
                    //�� ������Ʈ�� ��ȣ�ۿ� ȿ�� ����� I_Interplay_effect�� ��ӹ���.
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
