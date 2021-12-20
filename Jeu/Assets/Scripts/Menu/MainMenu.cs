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
    /// when the play button is pressed, load the scene 1 in build
    ///<summary>
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    ///<summary>
    /// when the quit button is pressed, quit the game
    ///<summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Crédits");
    }
}