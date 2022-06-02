using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Player_head;
    private Renderer[] reander;
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
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Time.deltaTime);
        if(Vector3.Distance(transform.position, Player.transform.position) <= 1.0f)
        {
            Player_head.GetComponent<Interplay_Object>().enabled = true;
            this.gameObject.SetActive(false);
        }
    }
}
