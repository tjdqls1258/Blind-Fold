using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire_Bullte : MonoBehaviour
{
    [Header("Bullte Setting")]
    
    public List<GameObject> Bullte;
    [SerializeField] private float ScrollSeepd = 10.0f;
    [SerializeField] private int Bullte_Index;
    public Image Bullte_Image;
    private float Scroll_Index;

    [SerializeField] private Transform fir_Pos;

    [Header("InGame Shotting Setting")]
    [SerializeField] private int Count_Bullte = 0;
    [SerializeField] private int Max_Count_Bullte = 1;
    [SerializeField] private float Delay = 1.0f;
    private bool Can_Fire = true;

    [Header("돌 던지는 파워정도")]
    [SerializeField] private float Throw_Power = 0.0f;
    [SerializeField] private float Min_Throw_Power = 1.0f;
    [SerializeField] private float Max_Throw_Power = 10.0f;
    public Image Throw_Power_Charge;

    [SerializeField] private Text interplay;
    //총알 발사
    private void Awake()
    {
        Bullte = new List<GameObject>();
        Bullte_Index = 0;
    }

    private void OnEnable()
    {
        Can_Fire = true;
    }

    private void Update()
    {
        Selete_Rock();
        Fire_Bullte_Function();
    }

    private void Selete_Rock()
    {
        if(Bullte.Count <= 1)
        {
            Bullte_Index = 0;
            if (Bullte.Count != 0)
            {
                Bullte_Image.sprite = Bullte[Bullte_Index].GetComponent<Rock_Interplay>().Rock_Image;
            }
            return;
        }
        Scroll_Index = Input.GetAxis("Mouse ScrollWheel") * ScrollSeepd;
        if(Scroll_Index < 0 || Scroll_Index > 0)
        {
            Bullte_Index = (int)Scroll_Index;
        }
        if(Bullte.Count + 1 < Bullte_Index)
        {
            Bullte_Index = Bullte.Count;
        }
        else if (Bullte_Index < 0)
        {
            Bullte_Index = 0;
        }
        Bullte_Image.sprite = Bullte[Bullte_Index].GetComponent<Rock_Interplay>().Rock_Image;
    }

    private void Fire_Bullte_Function()
    {
        if (Input.GetMouseButton(0) && Can_Fire && Count_Bullte > 0)
        {
            if (Throw_Power >= Max_Throw_Power)
            {
                Throw_Power = Max_Throw_Power;
            }
            else if (Throw_Power <= Min_Throw_Power)
            {
                Throw_Power = Min_Throw_Power;
            }
            Throw_Power += Time.deltaTime * 10.0f;
            Throw_Power_Charge.fillAmount = Throw_Power / Max_Throw_Power;
        }
        if (Input.GetMouseButtonUp(0) /*&& Can_Fire*/ && Count_Bullte > 0)
        {
            if (Can_Fire)
            {
                Instantiate(Bullte[Bullte_Index], fir_Pos.transform.position, fir_Pos.transform.rotation);
                Bullte.RemoveAt(Bullte_Index);
                if(Bullte_Index > Bullte.Count)
                {
                    Bullte_Image.sprite = Bullte[Bullte_Index].GetComponent<Rock_Interplay>().Rock_Image;
                }
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
