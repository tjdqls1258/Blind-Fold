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

    public void add_Count_Bullte(int count)
    {
        Count_Bullte = Count_Bullte + count;
    }
    //Invoke는 오브젝트의 Action 유무에 관계없이 실행된다.
    // -> 함수 자체가 딜레이 이후에 실행된다는 이야기이다...?
    // 그런데 String 형태로 함수를 호출하기에 효율적이지 않다. (느리다는 느낌?)
    // 그래서 코루틴을 사용했다.
}
