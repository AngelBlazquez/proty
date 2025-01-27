﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class winManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Canvas;

    [SerializeField]
    private GameObject nextLevelInput;
    [SerializeField]
    private GameObject resumeButton;

    [SerializeField]
    private TouchInput touchInput;

    [SerializeField]
    private StarManager stars;

    [SerializeField]
    private PlayerMovement playerMvt;

    private int nextLevelNumber;

    void start() {
        stars.GetComponent<StarManager>().hideStars();
    }

    void Update()
    {
        if ( (Input.GetButtonDown("ControllerEscape") || Input.GetKeyDown("escape")) && Time.timeScale == 1 ) {
            pauseGameMenu();
        }
    }

    // #FFF9C1FF
    // #C1FFFFFF

    // Methode who resume the game
    public void resume()
    {
        touchInput.ChangeVisibility(true);
        Cursor.visible = false;
        Time.timeScale = 1;
        Canvas.SetActive(false);
        playerMvt.enabled = true;
    }

    // Methode who show the pause game menu
    public void pauseGameMenu()
    {
        touchInput.ChangeVisibility(false);
        Cursor.visible = true;
        Time.timeScale = 0;
        Canvas.SetActive(true);
        nextLevelInput.SetActive(false);
        if(playerMvt != null)
        {
            playerMvt.enabled = false;
        }
        
        // controller button active
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(resumeButton);
    }

    // Methode who show the next win menu
    public void winGameMenu(int nextLevel)
    {
        touchInput.ChangeVisibility(false);
        Cursor.visible = true;
        nextLevelNumber = nextLevel;
        Time.timeScale = 0;
        //isPaused = true;
        resumeButton.SetActive(false);
        Canvas.SetActive(true);

        // controller button active
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(nextLevelInput);
    }

    // Method who load the next level
    public void nextLevelButton()
    {
        ChangeLevel.LoadLevel(nextLevelNumber);
        Canvas.SetActive(false);
        Time.timeScale = 1;
    }

    // Method who reload the level
    public void retryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Canvas.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    // Method who load the home menu
    public void menuButton()
    {
        // Appeler la méthode qui nous fait revenir dans un autre menu (menu principal)
        Cursor.visible = true;
        Debug.Log("Ok Menu");
        SceneManager.LoadScene("Menu");
        Canvas.SetActive(false);
        Time.timeScale = 1;
    }

    /// <summary>
    /// Show and unlock the stars defined by the end level script
    /// Author : Angel Blazquez
    /// </summary>
    public void ShowStars(int nbStars) {
        stars.GetComponent<StarManager>().displayStars();
        stars.GetComponent<StarManager>().UnlockStars(nbStars);
    }

    // Method who quit the game
    public void quitButton()
    {
        Application.Quit();
    }
}
