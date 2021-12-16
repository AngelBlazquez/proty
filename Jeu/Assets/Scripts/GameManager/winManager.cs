﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winManager : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject nextLevel;
    public GameObject resumeButton;
    public endLevel end_Level;

    void Update()
    {
        if (Input.GetKeyDown("escape") && Time.timeScale == 1) {
            pauseGameMenu();
        }
    }

    // #FFF9C1FF
    // #C1FFFFFF

    // Methode who resume the game
    public void resume()
    {
        Time.timeScale = 1;
        nextLevel.SetActive(true);
        Canvas.SetActive(false);
    }

    // Methode who show the pause game menu
    public void pauseGameMenu()
    {
        Time.timeScale = 0;
        Canvas.SetActive(true);
        nextLevel.SetActive(false);
    }

    // Methode who show the next win menu
    public void winGameMenu()
    {
        Time.timeScale = 0;
        //isPaused = true;
        resumeButton.SetActive(false);
        Canvas.SetActive(true);
    }

    // Method who load the next level
    public void nextLevelButton()
    {
        SceneManager.LoadScene(end_Level.NextScene());
        Canvas.SetActive(false);
        Time.timeScale = 1;
    }

    // Method who reload the level
    public void retryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Canvas.SetActive(false);
        Time.timeScale = 1;
    }

    // Method who load the home menu
    public void menuButton()
    {
        // Appeler la méthode qui nous fait revenir dans un autre menu (menu principal)
        Debug.Log("Ok Menu");
        SceneManager.LoadScene(0);
        Canvas.SetActive(false);
        Time.timeScale = 1;
    }

    // Method who quit the game
    public void quitButton()
    {
        Application.Quit();
    }
}