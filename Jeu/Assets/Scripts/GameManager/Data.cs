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
    public LevelsDisplay levels;

    private void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            SaveData();
        }
    }

    public void IncrementLevel()
    {

    }

    public void SaveData()
    {
        string dataJson = JsonUtility.ToJson(levels);
        string path = Application.persistentDataPath + "/LevelData.json";
        File.WriteAllText(path, dataJson);
        Debug.Log(path);
    }

    public void GetData()
    {
        try
        {
            string path = Application.persistentDataPath + "/LevelData.json";
            string dataJson = File.ReadAllText(path);
            levels = JsonUtility.FromJson<LevelsDisplay>(dataJson);
        }
        catch (FileNotFoundException e)
        {
            e.ToString();
            levels = new LevelsDisplay();
        }

    }
}

[System.Serializable]
public class LevelsDisplay
{
    public List<Level> levels;
    public GameObject chains;

    public LevelsDisplay()
    {

    }

}

[System.Serializable]
public class Level
{
    public GameObject levelDisplay;
    public int levelNumber;
    public bool isUnlocked = false;

}