using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire_Bullte : MonoBehaviour
{
    [Header("Bullte Setting")]
    public GameObject Bullte;
    [SerializeField] private Transform fir_Pos;
    [Header("InGame Shotting Setting")]
    [SerializeField] private int Count_Bullte = 0;
    [SerializeField] private float Delay = 1.0f;
    private bool Can_Fire = true;
    //총알 발사
    private void Update()
    {
        //다항 조건문인데 더 효율적인거 없을까.
        //일단 설명 마우스 좌클릭을 했고 총을 쏠수 있는 상황이며, 총알이 있을경우.
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

    public bool add_Count_Bullte()
    {
        if (Count_Bullte == 0)
        {
            Count_Bullte = 1;
            return true;
        }

        return false;
    }

    public int get_count_bullet()
    {
        return Count_Bullte;
    }
}
