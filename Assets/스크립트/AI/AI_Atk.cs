using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Atk : MonoBehaviour
{
    private GameObject Parent;
    [SerializeField] private GameObject Die_Cam;
    [SerializeField] private GameObject AI_ATk;
    public Emission_Effect Emission_Object;

    private void Start()
    {
        Parent = transform.parent.gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            if (Parent.GetComponent<State_Machine>())
            {
                Transform trans = collision.transform;
                collision.transform.gameObject.GetComponent<Player_Is_Die>().Is_Die();
                Emission_Object.Emission_This_Object(5.0f);
                Die_Cam.SetActive(true);
                AI_ATk.SetActive(true);
                StartCoroutine(Die_Player());
                Parent.GetComponent<SphereCollider>().enabled = false;
                Parent.GetComponent<State_Machine>().Change_State(new I_AttackState(Parent));
            }
        }
    }

    private IEnumerator Die_Player()
    {
        AI_ATk.GetComponent<Animator>().SetBool("Die", true);
        yield return new WaitForSeconds(AI_ATk.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).Length);
        Die_Cam.GetComponent<Animator>().SetBool("Die", true);
    }
}
