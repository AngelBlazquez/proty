using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>
/// main menu
/// by Guyot Vincent
///<summary>
public class MainMenu : MonoBehaviour
{
    ///<summary>
    /// when the play button is pressed, load the scene 1 in build (level select)
    ///<summary>
    public void PlayGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    ///<summary>
    /// when the quit button is pressed, quit the game
    ///<summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    ///<summary>
    /// when the credits button is pressed, load the credits scene
    ///<summary>
    public void LoadCredits()
    {
        SceneManager.LoadScene("Crédits");
    }
}