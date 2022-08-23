using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class Save_Data_Class
{
    public int Stage_num = 0;
}

public class Save_Data : MonoBehaviour
{
    private Save_Data_Class saveData = new Save_Data_Class();
    private string SAVE_DATA_DIRECTORY;

    // Start is called before the first frame update
    private void Awake()
    {
        Application.targetFrameRate = 60;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        SAVE_DATA_DIRECTORY = Application.dataPath + "/SaveFile.txt";

        if (Directory.Exists(SAVE_DATA_DIRECTORY))
        {
            Directory.CreateDirectory(SAVE_DATA_DIRECTORY);
        }
    }

    public void ResetData()
    {
        saveData.Stage_num = 1;
        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(SAVE_DATA_DIRECTORY, json);
    }

    public void SaveData()
    {
        saveData.Stage_num = SceneManager.GetActiveScene().buildIndex + 1;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(SAVE_DATA_DIRECTORY, json);
    }

    public void LoadData()
    {
        if (!File.Exists(SAVE_DATA_DIRECTORY))
        {
            Debug.Log("데이터 없음.");
            return;
        }
        string loadJson = File.ReadAllText(SAVE_DATA_DIRECTORY);

        saveData = JsonUtility.FromJson<Save_Data_Class>(loadJson);

       
    }

    public int LoadStage_Num()
    {
        SAVE_DATA_DIRECTORY = Application.dataPath + "/SaveFile.txt";

        if (Directory.Exists(SAVE_DATA_DIRECTORY))
        {
            Directory.CreateDirectory(SAVE_DATA_DIRECTORY);
            return 0;
        }

        if (!File.Exists(SAVE_DATA_DIRECTORY))
        {
            Debug.Log("데이터 없음.");
            return 0;
        }
        string loadJson = File.ReadAllText(SAVE_DATA_DIRECTORY);

        saveData = JsonUtility.FromJson<Save_Data_Class>(loadJson);

        return saveData.Stage_num;
    }
}