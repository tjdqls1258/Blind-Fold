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
//        //Ʃ�丮�� ����Ʈ 1�� �̵� Ʃ�丮��
//        step1();
//        yield return new WaitWhile(() => tutoquestnum < 1);

//        //Ʃ�丮�� ����Ʈ 2�� �ĵ� ���� �� ��ȣ�ۿ�
//        step2();
//        yield return new WaitWhile(() => tutoquestnum < 2);

//        //Ʃ�丮�� ����Ʈ 3�� ���� ����
//        step3();
//        yield return new WaitWhile(() => tutoquestnum < 3);
//    }

//    void step1()
//    {
//        bool script = false;
//        if (!script)
//        {
//            Time.timeScale = 0.0f;
//            //Ʃ�丮�� �Ұ� �ؽ�Ʈ �Է�(�̵� ����)
//            //��� �ؽ�Ʈ ���� �� �Ʒ��� �Ѿ����
//            tutotext.text = ;
//            if (Input.GetKeyDown(KeyCode.Mouse0))
//            {
//                tutotext.text = ;
//            }
//            script = true;
//        }

//        Time.timeScale = 1.0f;
//        if (/*�������� ������ ������ ���϶�*/)
//        {
//            //�������� ���� ����
//            //�߰� �ȳ� �ؽ�Ʈ
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
//            //�ĵ��� ���� ���� �� ��ȣ�ۿ� ����
//            script = true;
//        }

//        Time.timeScale = 1.0f;
//        //��ô���� ã�Ҵ��� ����
//        if (/*���ǰ� ��ȣ�ۿ� �ߴ��� && !script2*/)
//        {
//            Time.timeScale = 0.0f;
//            //��ô���� ã���� ������ �� ���� �� ���� ã�� ������ ����
//            Time.timeScale = 1.0f;

//            script2 = true;
//            tutoquestnum++;
//        }
//    }

//    void step3()
//    {
//        //���� ������ �ÿ� ���߰� ���� �������� ���� ����
//        Time.timeScale = 0.0f;
//        //������ ������ ��ٷ� Ż�����

//        Time.timeScale = 1.0f;

//        //if()
//        //Ʃ�丮�� Ŭ���� �Ŀ� ���θ޴��� ���ư���, �ٷ� ���������� ���� Ȯ���� �ۼ�
//        /**/
//    }
//}
