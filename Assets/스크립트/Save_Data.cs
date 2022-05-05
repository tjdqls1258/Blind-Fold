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

    [SerializeField] private Transform Player;
    [SerializeField] private Transform AI;

    // Start is called before the first frame update
    private void Awake()
    {
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

    public void SaveData()
    {
        saveData.Stage_num = SceneManager.GetActiveScene().buildIndex + 1;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(SAVE_DATA_DIRECTORY, json);

        Debug.Log("저장완료 : ");
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

        SceneManager.LoadScene(saveData.Stage_num);
    }
}