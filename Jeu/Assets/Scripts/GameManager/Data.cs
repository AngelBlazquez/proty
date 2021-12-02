using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Saves the level and loads it back
/// Made by Léo PUYASTIER
/// </summary>
public class Data : MonoBehaviour
{
        public List<Level> allLevels;
    [SerializeField]
    private CreateLevels loader;

    void Start() {
        GetData();
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
        string dataJson = JsonUtility.ToJson(allLevels);
        string path = Application.persistentDataPath + "/LevelData.json";
        File.WriteAllText(path, dataJson);
        Debug.Log("Sauvegarde des données");
        //Debug.Log(path);
    }
    
    public void GetData()
    {
        try
        {
            string path = Application.persistentDataPath + "/LevelData.json";
            string dataJson = File.ReadAllText(path);
            allLevels = JsonUtility.FromJson<List<Level>>(dataJson);
            if (allLevels.Count == 0) {
                throw new FileNotFoundException();
            }
        Debug.Log("Récupération des données");

        }
        catch (FileNotFoundException e)
        {
            e.ToString();
            allLevels = loader.levels;
        Debug.Log("Création des données");
                        SaveData();
        }

    }
}


/// <summary>
/// Creates a level that is displayable
/// Made by Léo PUYASTIER
/// </summary>
[System.Serializable]
public class Level
{
    public GameObject levelDisplay;
    public int levelNumber;
    public bool isUnlocked = false;

}