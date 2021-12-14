using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBindMenu : MonoBehaviour
{
    private Dictionary<string, KeyCode> Keys = new Dictionary<string, KeyCode>();

    public Text left, right, run, jump, pause;

    private GameObject currentKey;

    // Start is called before the first frame update
    void Start()
    {
        Keys.Add("LeftButton", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("LeftButton","LeftArrow")));
        Keys.Add("RightButton", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("RightButton","RightArrow")));
        Keys.Add("RunButton", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("RunButton","B")));
        Keys.Add("JumpButton", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("JumpButton","Space")));
        Keys.Add("PauseButton", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("PauseButton","W")));

        left.text = Keys["LeftButton"].ToString();
        right.text = Keys["RightButton"].ToString();
        run.text = Keys["RunButton"].ToString();
        jump.text = Keys["JumpButton"].ToString();
        pause.text = Keys["PauseButton"].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Keys["LeftButton"]))
        {
            Debug.Log("Left");
        }
        if (Input.GetKeyDown(Keys["RightButton"]))
        {
            Debug.Log("Right");
        }
        if (Input.GetKeyDown(Keys["RunButton"]))
        {
            Debug.Log("Run");
        }
        if (Input.GetKeyDown(Keys["JumpButton"]))
        {
            Debug.Log("Jump");
        }
        if (Input.GetKeyDown(Keys["PauseButton"]))
        {
            Debug.Log("Pause");
        }
        
    }

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

    public void ChangeKey(GameObject clicked)
    {
        currentKey = clicked;
    }

    public void SaveKeys()
    {
        foreach (var key in Keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }

        PlayerPrefs.Save();
    }
}
