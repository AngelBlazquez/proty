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
    [SerializeField]
    private SavableData data;
    [SerializeField]
    private LevelDisplayHolder levelDisplays;

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
            Debug.Log("Suppression des données");
            File.Delete(Application.persistentDataPath + "/LevelData.json");
        }
    }

    /// <summary>
    /// Creates a new set of data
    /// </summary>
    private void CreateData()
    {
        Debug.Log("Création des données");
        data = new SavableData(levelDisplays.GetDisplay().Count);

        SaveData();
    }

    /// <summary>
    /// Saves the data to a json file
    /// </summary>
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

    /// <summary>
    /// Loads the data from the file
    /// </summary>
    public void GetData()
    {
        string path = Application.persistentDataPath + "/LevelData.json";
        string dataJson = File.ReadAllText(path);
        JsonUtility.FromJsonOverwrite(dataJson, data);
        Debug.Log("Récupération des données");
    }

    /// <summary>
    /// Unlocks a particular level
    /// </summary>
    /// <param name="levelNumber"></param>
    public void UnlockLevel(int levelNumber)
    {
        data.GetLevels()[levelNumber].Unlock();
    }

    #region Getters
    public List<Level> GetLevels()
    {
        return data.GetLevels();
    }
    #endregion

}


/// <summary>
/// Holds all the data that needs to be saved
/// </summary>
[System.Serializable]
public class SavableData
{
    [SerializeField]
    private List<Level> allLevels;

    /// <summary>
    /// Creates a new List of Level
    /// </summary>
    /// <param name="size">The number of levels in the game</param>
    public SavableData(int size)
    {
        allLevels = new List<Level>();
        for (int i = 0; i < size; i++)
        {
            allLevels.Add(new Level(i));
        }
        allLevels[0].Unlock();
    }

    #region Getter
    public List<Level> GetLevels() { return allLevels; }
    #endregion
}

/// <summary>
/// Creates a level that is displayable
/// </summary>
[System.Serializable]
public class Level
{
    [SerializeField]
    private int levelNumber;
    [SerializeField]
    private bool isUnlocked;

    public Level(int levelNumber)
    {
        this.levelNumber = levelNumber;
        isUnlocked = false;
    }

    #region Getters and Setters
    public int GetNumber() { return levelNumber; }

    public bool GetIsUnlocked() { return isUnlocked; }

    // Setter
    public void Unlock() { isUnlocked = true; }
    #endregion
}