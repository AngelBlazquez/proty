using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Saves the level and loads it back
/// Made by Léo PUYASTIER
/// </summary>
public class DataManager : MonoBehaviour
{
    public SavableData data;
    [SerializeField]
    private CreateLevels loader;

    private void Awake()
    {
        if (File.Exists(Application.persistentDataPath + "/LevelData.json"))
        {
            GetData();
        }
        else
        {
            CreateData();
        }
    }

    private void CreateData()
    {
        Debug.Log("Création des données");
        data.allLevels = loader.levels;
        SaveData();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveData();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            GetData();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            File.Delete(Application.persistentDataPath + "/LevelData.json");
        }
    }

    public void SaveData()
    {
        string dataJson = JsonUtility.ToJson(data);
        Debug.Log(data);
        Debug.Log(dataJson);
        string path = Application.persistentDataPath + "/LevelData.json";
        File.WriteAllText(path, dataJson);
        Debug.Log("Sauvegarde des données");
        Debug.Log(path);
    }

    public void GetData()
    {

        string path = Application.persistentDataPath + "/LevelData.json";
        string dataJson = File.ReadAllText(path);
        JsonUtility.FromJsonOverwrite(dataJson, data);
        Debug.Log("Récupération des données");




    }
}

[System.Serializable]
public class SavableData
{
    public List<Level> allLevels;
}

/// <summary>
/// Creates a level that is displayable
/// Made by Léo PUYASTIER
/// </summary>
[System.Serializable]
public class Level
{
    [SerializeReference]
    public GameObject levelDisplay;
    public int levelNumber;
    public bool isUnlocked = false;
}