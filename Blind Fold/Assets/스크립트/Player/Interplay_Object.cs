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

        //오브젝트의 설명을 보이게 하기 위해서 먼저 레이를 쏴서 
        //앞에 오브젝트가 있는지 본다
        //그다음 해당 오브젝트가 상호작용할 수 있는 오브젝트인지 
        //해당 오브젝트에 상호작용 컴포넌트가 있는지 판단한다.
        //그리고 설명을 띄운 다음 플레이어가 E를 눌렀을때 상호작용 효과를 낸다.  

        //왜 이런구조로 짠것인가. E를 눌렀을때 레이를 쏴서 판단해도 되지 않는가? --> 
        //해당 오브젝트에 대한 설명만 보고 싶을 때 E를 누르면 바로 상호작용이 되버리기 때문에 좋지 않다.
        //어떻게 이거 하나로 서로 다른 상호작용 효과를 낼수 있는가?
        //이 에대한 해답은 Interplay_machice에 있다.
        //해당 오브젝트에 반드시 Interplay_machice 컴포넌트와 I_Interplay_effect를 상속받은 상호작용 효과를 구현한 
        //컴포넌트가 필요하다. (I_Interplay_effect애는 인터페이스다)
        //이제 Interplayer_machice에서 해당 상호작용 효과를 구현한 컴포넌트를 참조한다.
        //이후 Interplay_machice에서 참조한 컴포넌트의 효과를 Interplay함수를 통해서 불러와서 사용한다. 
        //이렇게하면 참조한 컴포넌트만 교체하는걸로 여러 효과를 낼수 있다고 생각된다.

        //왜 각 객체마다 if문으로 처리하지  않았나요?
        //이유는 간단하다. 상호작용하는 오브젝트가 많을수록 조건문이 늘어나게 되고 수가 많아질수록 수정이 복잡해진다.

        //스테이트 패턴에 가깝다고 생각된다.
        if (Physics.Raycast(ray, out hit, Ray_distance))
        {
            if (hit.transform.gameObject.GetComponent<Interplay_machice>())
            {
                Interplay_machice interplay = hit.transform.gameObject.GetComponent<Interplay_machice>();
                //설명 보이기

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log(hit.transform.gameObject.name);
                    interplay.Interplay();
                    //각 상호작용마다 Interplay_machice.cs가 필요함
                    //각 오브젝트의 상호작용 효과 기능은 I_Interplay_effect를 상속받음.
                }
            }
        }
    }
}
