using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Atk : MonoBehaviour
{
    private GameObject Parent;
    [SerializeField] private GameObject Die_Cam;

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
                Die_Cam.SetActive(true);
                StartCoroutine(Die_Player());
                Parent.GetComponent<SphereCollider>().enabled = false;
                Parent.GetComponent<State_Machine>().Change_State(new I_AttackState(Parent));
            }
        }
    }

    private IEnumerator Die_Player()
    {
        yield return new WaitForSeconds(1.0f);
        Die_Cam.GetComponent<Animator>().SetBool("Die", true);
    }
}
