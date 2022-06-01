using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject d_tel;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Player.transform.position = new Vector3(d_tel.transform.position.x, d_tel.transform.position.y, d_tel.transform.position.z);
            Player.transform.Rotate(new Vector3(d_tel.transform.rotation.x, d_tel.transform.rotation.y, d_tel.transform.rotation.z));
        }
    }
}
