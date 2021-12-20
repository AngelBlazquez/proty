using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

///<summary>
/// main menu
/// by Guyot Vincent
///<summary>
public class MainMenu : MonoBehaviour
{
    public GameObject playButton, sliderButton, configButton;

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

<<<<<<< HEAD
    /** Choose first selected button in option: slider */
    public void openOption()
    {
        // selected set null
        EventSystem.current.SetSelectedGameObject(null);
        // select sliderButton
        EventSystem.current.SetSelectedGameObject(sliderButton);
    }

    /** choose first selected button in main menu: play */
    public void openMainMenu()
    {
        // selected set null
        EventSystem.current.SetSelectedGameObject(null);
        // select playButton
        EventSystem.current.SetSelectedGameObject(playButton);
    }

    public void openKeyConfig()
    {
        // selected set null
        EventSystem.current.SetSelectedGameObject(null);
        // select playButton
        EventSystem.current.SetSelectedGameObject(configButton);
    }
}