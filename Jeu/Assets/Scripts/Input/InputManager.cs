using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Dictionary<string, KeyCode> Keys { get; set; }

    public InputManager()
    {
        Keys = new Dictionary<string, KeyCode>();
        Keys.Add("LeftButton", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("LeftButton", "LeftArrow")));
        Keys.Add("RightButton", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("RightButton", "RightArrow")));
        Keys.Add("RunButton", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("RunButton", "B")));
        Keys.Add("JumpButton", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("JumpButton", "Space")));
        Keys.Add("PauseButton", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("PauseButton", "Escape")));
        Keys.Add("TryhardButton", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("TryhardButton", "R")));
    }

    private static InputManager instance;

    public static InputManager Instance()
    {
        if (instance == null)
        {
            instance = new InputManager();
        }
        return instance;
    }
}