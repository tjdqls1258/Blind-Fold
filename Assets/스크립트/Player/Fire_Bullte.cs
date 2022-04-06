using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Bullte : MonoBehaviour
{
    [Header("Bullte Setting")]
    [SerializeField] GameObject Bullte;
    [SerializeField] Transform fir_Pos;
    [Header("InGame Shotting Setting")]
    [SerializeField] int Count_Bullte = 5;
    [SerializeField] float Delay = 1.0f;
    bool Can_Fire = true;
    //�Ѿ� �߻�
    private void Update()
    {
        //���� ���ǹ��ε� �� ȿ�����ΰ� ������.
        //�ϴ� ���� ���콺 ��Ŭ���� �߰� ���� ��� �ִ� ��Ȳ�̸�, �Ѿ��� �������.
        if (Input.GetMouseButtonDown(0) && Can_Fire && Count_Bullte > 0)
        {
            Instantiate(Bullte, fir_Pos.transform.position, fir_Pos.transform.rotation);
            Can_Fire = false;
            Count_Bullte -= 1;
            StartCoroutine(Change_Fire_Bullte());
        }
    }

    private IEnumerator Change_Fire_Bullte()
    {
        yield return new WaitForSeconds(Delay);
        Can_Fire = true;
    }

    public void add_Count_Bullte(int count)
    {
        Count_Bullte = Count_Bullte + count;
    }
    //Invoke�� ������Ʈ�� Action ������ ������� ����ȴ�.
    // -> �Լ� ��ü�� ������ ���Ŀ� ����ȴٴ� �̾߱��̴�...?
    // �׷��� String ���·� �Լ��� ȣ���ϱ⿡ ȿ�������� �ʴ�. (�����ٴ� ����?)
    // �׷��� �ڷ�ƾ�� ����ߴ�.
}
