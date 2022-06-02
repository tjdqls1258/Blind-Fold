using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragdown : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject D_pos;
    [SerializeField] GameObject Drag_Trap;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(destination());
        }
    }

    IEnumerator destination()
    {
        while(Player.transform.position.y > 2.0f)
        {
            Player.transform.position = Vector3.MoveTowards(Player.transform.position, D_pos.transform.position, Time.deltaTime * 10.0f);
            yield return new WaitForSeconds(0.1f);
        }       

        Drag_Trap.GetComponent<CapsuleCollider>().isTrigger = false;

        yield return new WaitForSeconds(0.1f);
    }
}
