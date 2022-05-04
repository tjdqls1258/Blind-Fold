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
    private Save_Data_Class saveData = new Save_Data_Class();
    private string SAVE_DATA_DIRECTORY;

    void Start()
    {
        SAVE_DATA_DIRECTORY = Application.dataPath + "/SaveFile.txt";

        if(Directory.Exists(SAVE_DATA_DIRECTORY))
        {
            Directory.CreateDirectory(SAVE_DATA_DIRECTORY);
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SaveData()
    {
        saveData.Stage_num = SceneManager.GetActiveScene().buildIndex;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(SAVE_DATA_DIRECTORY, json);

        Debug.Log("저장완료 : ");
    }

    public int LoadData()
    {
        if(! File.Exists(SAVE_DATA_DIRECTORY))
        {
            Debug.Log("데이터 없음.");
            return 0;
        }
        string loadJson = File.ReadAllText(SAVE_DATA_DIRECTORY);

        saveData = JsonUtility.FromJson<Save_Data_Class>(loadJson);

        return saveData.Stage_num;
    }
}
