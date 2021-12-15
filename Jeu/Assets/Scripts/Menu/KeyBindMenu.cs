using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
/// menu of keybinding
/// by Guyot Vincent
///<summary>
public class KeyBindMenu : MonoBehaviour
{
    private Dictionary<string, KeyCode> Keys = new Dictionary<string, KeyCode>();

    public Text left, right, run, jump, pause;

    private GameObject currentKey;

    ///<summary>
    /// Add every couple of string and keys to the dictionary and add the text to the button
    ///<summary>
    void Start()
    {
        Keys.Add("LeftButton", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("LeftButton","LeftArrow")));
        Keys.Add("RightButton", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("RightButton","RightArrow")));
        Keys.Add("RunButton", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("RunButton","B")));
        Keys.Add("JumpButton", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("JumpButton","Space")));
        Keys.Add("PauseButton", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("PauseButton","Escape")));

        left.text = Keys["LeftButton"].ToString();
        right.text = Keys["RightButton"].ToString();
        run.text = Keys["RunButton"].ToString();
        jump.text = Keys["JumpButton"].ToString();
        pause.text = Keys["PauseButton"].ToString();
    }

    ///<summary>
    /// if a button to link a key is clicked, wait for the user to press a key to reassign
    ///<summary>
    void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                Keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey = null;
            }
        }
    }

    ///<summary>
    /// call if the button link to a key is clicked
    ///<summary>
    public void ChangeKey(GameObject clicked)
    {
        currentKey = clicked;
    }

    ///<summary>
    /// save the keys assigned by the player
    ///<summary>
    public void SaveKeys()
    {
        foreach (var key in Keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }

        PlayerPrefs.Save();
    }
}
