﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

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
        if (File.Exists(Application.persistentDataPath + "/LevelData.lp"))
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
            File.Delete(Application.persistentDataPath + "/LevelData.lp");
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log("Triche détectée, votre tentative sera signalée à la police >:(");
            for (int i = 0; i < data.GetLevels().Count; i++)
            {
                UnlockLevel(i);
            }
            SaveData();
        }
    }

    /// <summary>
    /// Creates a new set of data
    /// </summary>
    private void CreateData()
    {
        data = new SavableData(levelDisplays.GetDisplay().Count, levelDisplays.GetVersion());

        SaveData();
    }

    /// <summary>
    /// Saves the data to a json file
    /// </summary>
    public void SaveData()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/LevelData.lp";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);

        stream.Close();
    }

    /// <summary>
    /// Loads the data from the file
    /// </summary>
    public void GetData()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/LevelData.lp";
        FileStream stream = new FileStream(path, FileMode.Open);

        data = formatter.Deserialize(stream) as SavableData;

        stream.Close();

        if (data.GetVersion() == 0 || data.GetVersion() < levelDisplays.GetVersion())
        {
            data.Update(levelDisplays.GetDisplay().Count, levelDisplays.GetVersion());
            SaveData();
        }

        data.UpdateTraps();
    }

    /// <summary>
    /// Unlocks a particular level
    /// </summary>
    /// <param name="levelNumber"></param>
    public void UnlockLevel(int levelNumber)
    {
        data.UnlockLevel(levelNumber);
    }



    public void SaveTime(int levelNumber, int time)
    {
        data.SaveTime(levelNumber, time);
        SaveData();
    }

    #region Getters
    public List<Level> GetLevels()
    {
        return data.GetLevels();
    }

    public int GetTime(int levelNumber)
    {
        return data.GetTime(levelNumber);
    }

    public void AddDeath()
    {
        data.AddDeath();
        SaveData();
    }

    public int GetDeath()
    {
        return data.GetDeath();
    }

    public void AddDeathLevel(int levelNumber)
    {
        data.AddDeathLevel(levelNumber);
        SaveData();
    }

    public int GetDeathLevel(int levelNumber)
    {
        return data.GetDeathLevel(levelNumber);
    }

    public void AddDeathTraps(string tag)
    {
        data.AddDeathTraps(tag);
        SaveData();
    }

    public int GetDeathTraps(string tag)
    {
        return data.GetDeathTraps(tag);
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
    [SerializeField]
    private float version;
    [SerializeField]
    private int nbDeath;
    [SerializeField]
    private Dictionary<string,Traps> allTraps;

    /// <summary>
    /// Creates a new List of Level
    /// </summary>
    /// <param name="size">The number of levels in the game</param>
    public SavableData(int size, float version)
    {
        allLevels = new List<Level>();
        for (int i = 0; i < size; i++)
        {
            allLevels.Add(new Level(i));
        }
        allLevels[0].Unlock();
        this.version = version;
        nbDeath = 0;
    }

    public void Update(int newSize, float version)
    {
        if (newSize >= allLevels.Count)
        {
            for (int i = allLevels.Count; i < newSize; i++)
            {
                allLevels.Add(new Level(i));
            }
        }
        else
        {
            for (int i = newSize; i < allLevels.Count; i++)
            {
                allLevels.Remove(allLevels[i]);
            }
        }
        this.version = version;
    }

    public void UpdateTraps()
    {
        allTraps = new Dictionary<string,Traps>();
        allTraps.Add("Void", new Traps("Void"));
        allTraps.Add("Spikes", new Traps("Spikes"));
        allTraps.Add("Saw", new Traps("Saw"));
        allTraps.Add("Axes", new Traps("Axes"));
        allTraps.Add("Lasers", new Traps("Lasers"));
        allTraps.Add("Thwamp", new Traps("Thwamp"));
        allTraps.Add("Rain", new Traps("Rain"));
        allTraps.Add("CannonBall", new Traps("CannonBall"));
    }

    #region Getter & Setter
    public List<Level> GetLevels() { return allLevels; }


    /// <summary>
    /// Unlocks a particular level
    /// </summary>
    /// <param name="levelNumber"></param>
    public void UnlockLevel(int levelNumber)
    {
        allLevels[levelNumber].Unlock();
    }

    public void SaveTime(int levelNumber, int time)
    {
        allLevels[levelNumber].SaveTime(time);
    }

    public int GetTime(int levelNumber)
    {
        return allLevels[levelNumber].GetTime();
    }

    public float GetVersion()
    {
        return version;
    }

    public void AddDeath() { nbDeath++; }

    public int GetDeath() { return nbDeath; }

    public void AddDeathLevel(int levelNumber)
    {
        allLevels[levelNumber].SetDeath();
    }

    public int GetDeathLevel(int levelNumber)
    {
        return allLevels[levelNumber].GetDeath();
    }

    public void AddDeathTraps(string tag)
    {
        if (allTraps.ContainsKey(tag)) {
            allTraps[tag].AddDeath();
        }
    }

    public int GetDeathTraps(string tag)
    {
        int death = 0;
        if (allTraps.ContainsKey(tag)) {
            death = allTraps[tag].GetDeath();
        }
        return death;
    }

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
    [SerializeField]
    private int bestTime;
    [SerializeField]
    private int[] stars;

    private int death = 0;

    public Level(int levelNumber)
    {
        this.levelNumber = levelNumber;
        isUnlocked = false;
        bestTime = 0;
        death = 0;
    }

    #region Getters and Setters
    public int GetNumber() { return levelNumber; }

    public bool GetIsUnlocked() { return isUnlocked; }

    // Setter
    public void Unlock() { isUnlocked = true; }

    public void SaveTime(int time)
    {
        if (bestTime == 0 || time < bestTime)
        {
            bestTime = time;
            Debug.Log("Meilleur temps : " + time);
        }
    }

    public int GetTime() { return bestTime; }

    public void SetDeath()
    {
        death++;
    }

    public int GetDeath() { return death; }
    #endregion
}

[System.Serializable]
public class Traps
{
    [SerializeField]
    private string tag;

    private int death;

    public Traps(string tag)
    {
        this.tag = tag;
        death = 0;
    }

    public int GetDeath()
    {
        return death;
    }

    public void AddDeath()
    {
        death++;
    }

    public string GetTag()
    {
        return tag;
    }
}