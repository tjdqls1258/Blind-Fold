using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interplay_Object : MonoBehaviour
{
    private RaycastHit hit;
    private Ray ray;
    public float Ray_distance;

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //������Ʈ�� ������ ���̰� �ϱ� ���ؼ� ���� ���̸� ���� 
        //�տ� ������Ʈ�� �ִ��� ����
        //�״��� �ش� ������Ʈ�� ��ȣ�ۿ��� �� �ִ� ������Ʈ���� 
        //�ش� ������Ʈ�� ��ȣ�ۿ� ������Ʈ�� �ִ��� �Ǵ��Ѵ�.
        //�׸��� ������ ��� ���� �÷��̾ E�� �������� ��ȣ�ۿ� ȿ���� ����.  

        //�� �̷������� §���ΰ�. E�� �������� ���̸� ���� �Ǵ��ص� ���� �ʴ°�? --> 
        //�ش� ������Ʈ�� ���� ���� ���� ���� �� E�� ������ �ٷ� ��ȣ�ۿ��� �ǹ����� ������ ���� �ʴ�.
        //��� �̰� �ϳ��� ���� �ٸ� ��ȣ�ۿ� ȿ���� ���� �ִ°�?
        //�� ������ �ش��� Interplay_machice�� �ִ�.
        //�ش� ������Ʈ�� �ݵ�� Interplay_machice ������Ʈ�� I_Interplay_effect�� ��ӹ��� ��ȣ�ۿ� ȿ���� ������ 
        //������Ʈ�� �ʿ��ϴ�. (I_Interplay_effect�ִ� �������̽���)
        //���� Interplayer_machice���� �ش� ��ȣ�ۿ� ȿ���� ������ ������Ʈ�� �����Ѵ�.
        //���� Interplay_machice���� ������ ������Ʈ�� ȿ���� Interplay�Լ��� ���ؼ� �ҷ��ͼ� ����Ѵ�. 
        //�̷����ϸ� ������ ������Ʈ�� ��ü�ϴ°ɷ� ���� ȿ���� ���� �ִٰ� �����ȴ�.

        //�� �� ��ü���� if������ ó������  �ʾҳ���?
        //������ �����ϴ�. ��ȣ�ۿ��ϴ� ������Ʈ�� �������� ���ǹ��� �þ�� �ǰ� ���� ���������� ������ ����������.

        //������Ʈ ���Ͽ� �����ٰ� �����ȴ�.
        if (Physics.Raycast(ray, out hit, Ray_distance))
        {
            if (hit.transform.gameObject.GetComponent<Interplay_machice>())
            {
                Interplay_machice interplay = hit.transform.gameObject.GetComponent<Interplay_machice>();
                //���� ���̱�

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log(hit.transform.gameObject.name);
                    interplay.Interplay();
                    //�� ��ȣ�ۿ븶�� Interplay_machice.cs�� �ʿ���
                    //�� ������Ʈ�� ��ȣ�ۿ� ȿ�� ����� I_Interplay_effect�� ��ӹ���.
                }
            }
        }
    }
}
