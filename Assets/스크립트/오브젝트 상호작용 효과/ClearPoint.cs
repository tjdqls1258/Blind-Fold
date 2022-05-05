using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearPoint : MonoBehaviour
{
    //[SerializeField] GameObject Player;
    //[SerializeField] int target_num;

    public void Clear()
    {
        if(GameObject.Find("StageManger").GetComponent<Save_Data>())
        {
            GameObject.Find("StageManger").GetComponent<Save_Data>().SaveData();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
