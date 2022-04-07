using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Atk : MonoBehaviour
{
    private GameObject Parent;

    private void Start()
    {
        Parent = gameObject.transform.parent.gameObject;
        Debug.Log(Parent.ToString());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            if (Parent.GetComponent<State_Machine>())
            {
                collision.transform.gameObject.GetComponent<Player_Is_Die>().Is_Die();
                Parent.GetComponent<SphereCollider>().enabled = false;
                Parent.GetComponent<State_Machine>().Change_State(new I_AttackState(Parent));
            }
        }
    }
}
