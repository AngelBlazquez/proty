using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>
/// Credits script
/// by Guyot Vincent
///<summary>
public class Credits : MonoBehaviour
{
    ///<summary>
    /// Load the main menu at the end of the credits
    ///<summary>
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    ///<summary>
    /// Skip the credits with pressing Space or Escape
    ///<summary>
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape) || (Input.GetButtonDown("ControllerEscape")))
        {
            LoadMenu();
        }
    }
}