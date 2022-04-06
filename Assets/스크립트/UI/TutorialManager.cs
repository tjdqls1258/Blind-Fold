//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class TutorialManager : MonoBehaviour
//{
//    private int tutoquestnum;
//    [SerializeField] Text tutotext;

//    void Start()
//    {
//        tutoquestnum = 0;
//        StartCoroutine(Tutorial());
//    }

//    IEnumerator Tutorial()
//    {
//        yield return new WaitForSeconds(0.5f);
//        //튜토리얼 퀘스트 1번 이동 튜토리얼
//        step1();
//        yield return new WaitWhile(() => tutoquestnum < 1);

//        //튜토리얼 퀘스트 2번 파동 이해 및 상호작용
//        step2();
//        yield return new WaitWhile(() => tutoquestnum < 2);

//        //튜토리얼 퀘스트 3번 적과 조우
//        step3();
//        yield return new WaitWhile(() => tutoquestnum < 3);
//    }

//    void step1()
//    {
//        bool script = false;
//        if (!script)
//        {
//            Time.timeScale = 0.0f;
//            //튜토리얼 소개 텍스트 입력(이동 관련)
//            //모든 텍스트 종료 후 아래로 넘어가야함
//            tutotext.text = ;
//            if (Input.GetKeyDown(KeyCode.Mouse0))
//            {
//                tutotext.text = ;
//            }
//            script = true;
//        }

//        Time.timeScale = 1.0f;
//        if (/*도착지점 도착시 조건이 참일때*/)
//        {
//            //도착지점 조명 꺼짐
//            //추가 안내 텍스트
//            tutoquestnum++;
//        }
//    }

//    void step2()
//    {
//        bool script = false;
//        bool script2 = false;
//        if (!script)
//        {
//            Time.timeScale = 0.0f;
//            //파동에 대한 설명 후 상호작용 설명
//            script = true;
//        }

//        Time.timeScale = 1.0f;
//        //투척물을 찾았는지 조건
//        if (/*물건과 상호작용 했는지 && !script2*/)
//        {
//            Time.timeScale = 0.0f;
//            //투척물을 찾으면 던지는 법 설명 후 문을 찾는 것으로 설명
//            Time.timeScale = 1.0f;

//            script2 = true;
//            tutoquestnum++;
//        }
//    }

//    void step3()
//    {
//        //문을 열었을 시에 멈추고 적과 조우했을 때의 설명
//        Time.timeScale = 0.0f;
//        //설명이 끝나면 곧바로 탈출까지

//        Time.timeScale = 1.0f;

//        //if()
//        //튜토리얼 클리어 후에 메인메뉴로 돌아갈지, 바로 본게임으로 갈지 확인후 작성
//        /**/
//    }
//}
