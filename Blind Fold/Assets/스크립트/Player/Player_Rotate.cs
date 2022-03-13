using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Rotate : MonoBehaviour
{
    float Rotate_X;
    float Rotate_Y;
    public float rotspeed = 200;

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

        Rotate_X = Mathf.Clamp(Rotate_X, -80, 80);

        transform.eulerAngles = new Vector3(-Rotate_X, Rotate_Y, 0);
    }
}
