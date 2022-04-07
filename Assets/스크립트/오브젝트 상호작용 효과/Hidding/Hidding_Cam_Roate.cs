using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hidding_Cam_Roate : MonoBehaviour
{
    Camera Cam;
    float Rotate_X;
    float Rotate_Y;
    [SerializeField] private float rotspeed = 200;
    [SerializeField, Range(0, 100)] private float Max_UpDown_Angle_Limit = 65;

    void Start()
    {
        Cam = GetComponent<Camera>();
    }

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

        Rotate_X = Mathf.Clamp(Rotate_X, -Max_UpDown_Angle_Limit, Max_UpDown_Angle_Limit);
        Rotate_Y = Mathf.Clamp(Rotate_Y, -Max_UpDown_Angle_Limit, Max_UpDown_Angle_Limit);
        Cam.transform.eulerAngles = new Vector3(-Rotate_X, Rotate_Y, 0);
    }
}
