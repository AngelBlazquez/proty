using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Audio;
using UnityEngine.UI;

///<summary>
/// main menu
/// by Guyot Vincent
///<summary>
public class MainMenu : MonoBehaviour
{
    public GameObject playButton, sliderButton, configButton, skinMenu, backSkinButton,mainMenu;

    public SettingsMenu settings;

    void Start()
    {
        settings.setVolume(PlayerPrefs.GetFloat("VolumeSave"));
        skinMenu.SetActive(false);
        
    }

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

    /** Choose first selected button in option: slider */
    public void openOption()
    {
        // selected set null
        EventSystem.current.SetSelectedGameObject(null);
        // select sliderButton
        EventSystem.current.SetSelectedGameObject(sliderButton);

        /*
        if (Screen.fullScreen)
        {
            checkMark.setActive(true);
        }
        else
        {
            checkMark.setActive(false);
        }
        */
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

    ///<summary>
    /// when the credits button is pressed, load the credits scene
    ///<summary>
    public void LoadCredits()
    {
        SceneManager.LoadScene("Crédits");
    }

    /// <summary>
    /// When the skin button is pressed.
    /// </summary>
    public void openSkinMenu()
    {
        skinMenu.SetActive(true);
        mainMenu.SetActive(false);
        // selected set null
        EventSystem.current.SetSelectedGameObject(null);
        // select skinMenu
        EventSystem.current.SetSelectedGameObject(backSkinButton);
    }

    public void closedSkinMenu()
    {
        skinMenu.SetActive(false);
        mainMenu.SetActive(true);
        // selected set null
        EventSystem.current.SetSelectedGameObject(null);
        // select skinMenu
        EventSystem.current.SetSelectedGameObject(playButton);
    }
}