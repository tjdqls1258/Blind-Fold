using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearPoint : MonoBehaviour
{
    public GameObject Player;

    public int target_num;

    private void OnTriggerEnter(Collider other)
    {
        if((other.tag == "Player") && (Player.GetComponent<Player_Move>().collect_key >= target_num))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
