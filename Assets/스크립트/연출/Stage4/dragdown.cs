using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragdown : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject D_pos;
    [SerializeField] GameObject Drag_Trap;
    [SerializeField] GameObject hand;
    [SerializeField] GameObject trap_base;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Player.GetComponent<Player_Move>().enabled = false;
            hand.SetActive(true);
            //trap_base.GetComponent<Animator>().SetBool("Is_Coll", true);
            Player.transform.position = transform.position;
            trap_base.transform.position = trap_base.transform.position - trap_base.transform.up * 1.2f;
            StartCoroutine(destination());
        }
    }

    IEnumerator destination()
    {
        while(Player.transform.position.y > 2.0f)
        {
            Player.transform.Translate(-Vector3.up * Time.fixedDeltaTime * 40.0f);
            trap_base.transform.Translate(-Vector3.up * Time.fixedDeltaTime * 40.0f);
            // Player.transform.position = Vector3.MoveTowards(Player.transform.position, D_pos.transform.position, Time.deltaTime * 100.0f);
            //trap_base.transform.position = Vector3.MoveTowards(Player.transform.position - Vector3.up*1.0f, D_pos.transform.position, Time.deltaTime * 100.0f);
            yield return new WaitForSeconds(0.1f);
        }

        Destroy(trap_base);
        Drag_Trap.GetComponent<CapsuleCollider>().isTrigger = false;
        Player.GetComponent<Player_Move>().enabled = true;

        yield return new WaitForSeconds(0.1f);
    }
}
