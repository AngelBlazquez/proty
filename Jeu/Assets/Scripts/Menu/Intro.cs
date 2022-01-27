using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>
/// Introduction script
/// by Guyot Vincent
///<summary>
public class Intro : MonoBehaviour
{
    ///<summary>
    /// Load the main menu at the end of the credits
    ///<summary>
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void setFullScreen()
    {
        Screen.fullScreen = true;
    }
}