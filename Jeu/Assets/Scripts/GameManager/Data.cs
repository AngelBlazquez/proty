using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public int lastLevel;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.S)) {
            SaveData();
        }
    }

    public void SaveData() {
        string dataJson = JsonUtility.ToJson(lastLevel);
        string path = Application.persistentDataPath + "/LevelData.json";
        Debug.Log(path);
        System.IO.File.WriteAllText(path, dataJson); 
    }
}
