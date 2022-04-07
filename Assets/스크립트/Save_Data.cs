using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;


[System.Serializable]
public class Save_Data_Class
{
    public Vector3 Player_Pos;
    public Quaternion Player_Rotate;

    public Vector3 Enemy_Pos;
    public Quaternion Enemy_Rotate;
}

public class Save_Data : MonoBehaviour
{
    private Save_Data_Class saveData = new Save_Data_Class();
    private string SAVE_DATA_DIRECTORY;

    [SerializeField] private Transform Player;
    [SerializeField] private Transform AI;

    // Start is called before the first frame update
    void Start()
    {
        SAVE_DATA_DIRECTORY = Application.dataPath + "/SaveFile.txt";

        if(Directory.Exists(SAVE_DATA_DIRECTORY))
        {
            Directory.CreateDirectory(SAVE_DATA_DIRECTORY);
        }
    }

    public void SaveData()
    {
        Player = GameObject.Find("Player").transform;
        AI = GameObject.Find("AI").transform;

        saveData.Player_Pos = Player.position;
        saveData.Player_Rotate = Player.rotation;

        saveData.Enemy_Pos = AI.position;
        saveData.Enemy_Rotate = AI.rotation;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(SAVE_DATA_DIRECTORY, json);

        Debug.Log("저장완료 : ");
    }

    public void LoadData()
    {
        if(! File.Exists(SAVE_DATA_DIRECTORY))
        {
            Debug.Log("데이터 없음.");
            return;
        }
        string loadJson = File.ReadAllText(SAVE_DATA_DIRECTORY);

        saveData = JsonUtility.FromJson<Save_Data_Class>(loadJson);

        Player = GameObject.Find("Player").transform;
        AI = GameObject.Find("AI").transform;
        

        Player.position = saveData.Player_Pos;
        Player.rotation = saveData.Player_Rotate;

        AI.position = saveData.Enemy_Pos;
        AI.rotation = saveData.Enemy_Rotate;
        AI.GetComponent<EnemyAI>().Repeating_Patrol();
        Debug.Log("로드 완료.");
    }
}
