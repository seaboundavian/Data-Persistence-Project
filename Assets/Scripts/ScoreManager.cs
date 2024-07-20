using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using File = System.IO.File;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    
    public int highest_M_Points;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Instance Destroyed");
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }
    
    [System.Serializable]
    class SaveData
    {
        public int highest_M_Points;
    }
    
    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.highest_M_Points = highest_M_Points;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            if (ScoreManager.Instance != null)
            {
                highest_M_Points = data.highest_M_Points;
            }
            
        }
    }
}
