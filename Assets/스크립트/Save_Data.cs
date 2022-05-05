using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class Save_Data_Class
{
    public int Stage_num;
}

public class Save_Data : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("Save_Stage", SceneManager.GetActiveScene().buildIndex);
    }

    public int LoadData()
    {
        return PlayerPrefs.GetInt("Save_Stage", 0);
    }
}
