using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4_05_start : MonoBehaviour
{
    [SerializeField] private GameObject Object;
    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player")
        {
            Object.transform.LookAt(other.transform);
            ClampXAxisRotationToValue(0.0f);
            ClampZAxisRotationToValue(0.0f);
        }
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = Object.transform.eulerAngles;
        eulerRotation.x = value;
        Object.transform.eulerAngles = eulerRotation;
    }

    private void ClampZAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = Object.transform.eulerAngles;
        eulerRotation.z = value;
        Object.transform.eulerAngles = eulerRotation;
    }
}
