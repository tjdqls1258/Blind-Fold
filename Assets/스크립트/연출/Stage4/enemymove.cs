using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Player_head;
    private Renderer[] reander;

    Vector3 p_chase;

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Animator>().SetBool("Is_Walk", true);
        reander = GetComponentsInChildren<Renderer>();

        foreach (Renderer child in reander)
        {
            child.material.SetFloat("_Emission", 0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        p_chase = Player.transform.position;
        p_chase.y = transform.position.y;
        transform.position = Vector3.MoveTowards(transform.position, p_chase, Time.deltaTime);
        transform.LookAt(p_chase);
        if(Vector3.Distance(transform.position, p_chase) <= 1.0f)
        {
            Player_head.GetComponent<Interplay_Object>().enabled = true;
            this.gameObject.SetActive(false);
        }
    }
}
