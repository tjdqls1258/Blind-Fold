using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_InterPlay : MonoBehaviour, I_Interplay_effect
{
    Animator animator;
    [SerializeField] bool It_Close = true;
    [SerializeField] bool Isclear = false;
    [SerializeField] int key_num;
    [SerializeField] AudioClip Door_Open_Sound_Clip;
    [SerializeField] AudioClip Door_Close_Sound_Clip;
    [SerializeField] AudioSource Sourece;

[SerializeField] GameObject Player;

    private void Awake()
    {
        //해당 컴포넌트를 Interplay_machice에 참조시킨다.
        Sourece = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        GetComponent<Interplay_machice>().SetInterplay(this);
        animator.SetBool("SwitchDoor", It_Close);
        if (It_Close)
        {
            GetComponent<Interplay_machice>().Exposition = "문 열기";
        }
        else
        {
            GetComponent<Interplay_machice>().Exposition = "문 닫기";
        }
    }

    public void Effect()
    {
        if (Player.GetComponent<Player_Move>().collect_key >= key_num)
        {
            animator.SetBool("SwitchDoor", It_Close);
            if (It_Close)
            {
                Sourece.PlayOneShot(Door_Open_Sound_Clip);
                GetComponent<Interplay_machice>().Exposition = "문 열기";
            }
            else
            {
                Sourece.PlayOneShot(Door_Close_Sound_Clip);
                GetComponent<Interplay_machice>().Exposition = "문 닫기";
            }
            It_Close = !It_Close;

            if (Isclear)
            {
                Player.GetComponent<Player_Hidding>().Is_Hidding_Start();
                StartCoroutine(Wait());
            }
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        GetComponent<ClearPoint>().Clear();
    }
}
