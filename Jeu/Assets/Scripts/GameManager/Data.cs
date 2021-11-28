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
    public LastLevelNumber lastLevel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveData();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GetData();
        }
    }
    public void IncrementLevel()
    {
        lastLevel.IncrementLevel();
    }

    public void SaveData()
    {
        string dataJson = JsonUtility.ToJson(lastLevel);
        string path = Application.persistentDataPath + "/LevelData.json";
        File.WriteAllText(path, dataJson);
    }

    public void GetData()
    {
        try
        {
            string path = Application.persistentDataPath + "/LevelData.json";
            string dataJson = File.ReadAllText(path);
            lastLevel = JsonUtility.FromJson<LastLevelNumber>(dataJson);
        }
        catch (FileNotFoundException e)
        {
            lastLevel = new LastLevelNumber();
        }

    }
}

[System.Serializable]
public class LastLevelNumber
{
    public int lastLevel;

    public LastLevelNumber()
    {
        lastLevel = 1;
    }

    public void IncrementLevel()
    {
        lastLevel++;
    }
}