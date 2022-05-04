using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire_Bullte : MonoBehaviour
{
    [Header("Bullte Setting")]
    
    public Queue<GameObject> Bullte;
    [SerializeField] private Transform fir_Pos;

    [Header("InGame Shotting Setting")]
    [SerializeField] private int Count_Bullte = 0;
    [SerializeField] private int Max_Count_Bullte = 1;
    [SerializeField] private float Delay = 1.0f;
    private bool Can_Fire = true;

    [Header("�� ������ �Ŀ�����")]
    [SerializeField] private float Throw_Power = 0.0f;
    [SerializeField] private float Min_Throw_Power = 1.0f;
    [SerializeField] private float Max_Throw_Power = 10.0f;
    public Image Throw_Power_Charge;

    [SerializeField] private Text interplay;
    //�Ѿ� �߻�
    private void Awake()
    {
        Bullte = new Queue<GameObject>();
    }

    private void OnEnable()
    {
        Can_Fire = true;
    }

    private void Update()
    {
        //���� ���ǹ��ε� �� ȿ�����ΰ� ������.
        //�ϴ� ���� ���콺 ��Ŭ���� �߰� ���� ��� �ִ� ��Ȳ�̸�, �Ѿ��� �������.
        
        if (Input.GetMouseButton(0) && Can_Fire && Count_Bullte > 0)
        {
            if (Throw_Power >= Max_Throw_Power)
            {
                Throw_Power = Max_Throw_Power;
            }
            else if(Throw_Power <= Min_Throw_Power)
            {
                Throw_Power = Min_Throw_Power;
            }
            Throw_Power += Time.deltaTime * 10.0f;
            Throw_Power_Charge.fillAmount = Throw_Power / Max_Throw_Power;
        }
        if(Input.GetMouseButtonUp(0) /*&& Can_Fire*/ && Count_Bullte > 0)
        {
            if(Can_Fire)
            {
                Instantiate(Bullte.Dequeue(), fir_Pos.transform.position, fir_Pos.transform.rotation);
                Count_Bullte -= 1;
            }
            Can_Fire = false;
            Throw_Power = 0;
            Throw_Power_Charge.fillAmount = Throw_Power / Max_Throw_Power;
            StartCoroutine(Change_Fire_Bullte());

            interplay.text = " ";
        }
        if (Input.GetMouseButtonDown(1))
        {
            Can_Fire = false;
            Throw_Power = 0;
            Throw_Power_Charge.fillAmount = Throw_Power / Max_Throw_Power;

            interplay.text = " ";
        }
    }

    private IEnumerator Change_Fire_Bullte()
    {
        yield return new WaitForSeconds(Delay);
        Can_Fire = true;
    }

    public bool add_Count_Bullte()
    {
        if (Count_Bullte < Max_Count_Bullte)
        {
            //GameObject.Find("Game_UI_Base").transform.Find("Stone").gameObject.SetActive(true);
            Count_Bullte += 1;
            return true;
        }

        return false;
    }

    public int get_count_bullet()
    {
        return Count_Bullte;
    }

    public float get_bullet_charge()
    {
        return Throw_Power;
    }
}
