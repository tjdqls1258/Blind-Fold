using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public float Move_Speed = 5;
    Rigidbody rigid;
    Relay_Sound relay;
    public GameObject Enemy;
    // Start is called before the first frame update
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        relay = GetComponent<Relay_Sound>();
    }

    private void Update()
    {
        move();
    }

    private void move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 dirset = Vector3.right * horizontal + Vector3.forward * vertical;

        dirset = Camera.main.transform.TransformDirection(dirset);
        dirset.Normalize(); //방향 구함. 
        dirset.y = 0;
        rigid.MovePosition(transform.position + dirset * Move_Speed * Time.deltaTime);
    }
}
