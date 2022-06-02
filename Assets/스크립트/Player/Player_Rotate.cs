using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Rotate : MonoBehaviour
{
    private float Rotate_X;
    private float Rotate_Y;
    public float rotspeed = 200;
    [SerializeField] private GameObject parent;

    void Update()
    {
        Rotate_actor();
    }

    private void Rotate_actor()
    {
        float mouse_x = Input.GetAxis("Mouse X");
        float mouse_y = Input.GetAxis("Mouse Y");

        Rotate_Y += rotspeed * mouse_x * Time.deltaTime;
        Rotate_X += rotspeed * mouse_y * Time.deltaTime;

        Rotate_X = Mathf.Clamp(Rotate_X, -50, 50);

        transform.eulerAngles = new Vector3(-Rotate_X, Rotate_Y, 0);
        parent.transform.eulerAngles = new Vector3(0, Rotate_Y, 0);
    }
}
